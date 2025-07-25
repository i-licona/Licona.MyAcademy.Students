using Newtonsoft.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Licona.MyAcademy.Students.Domain.Settings;
using Licona.MyAcademy.Students.Domain.Entities.Events;
using Licona.MyAcademy.Students.Domain.Entities.Tables;
using Licona.MyAcademy.Students.Domain.Ports.Repositories;

namespace Licona.MyAcademy.Students.Worker.Tasks;

public class KafkaConsumerCreatedTask(
    IOptions<KafkaSettings> kafkaSettings,
    IDatabaseRepository<Student> repository,
    ILogger<KafkaConsumerCreatedTask> logger
)
{
    private readonly ConsumerConfig _config = new()
    {
        GroupId = kafkaSettings.Value.GroupId,
        BootstrapServers = $"{kafkaSettings.Value.Hostname}:{kafkaSettings.Value.Port}",
        AutoOffsetReset = AutoOffsetReset.Earliest,
        EnableAutoCommit = false
    };

    private readonly string _topic = nameof(CreateStudentEvent);

    public async Task ConsumeEvent(CancellationToken cancellationToken)
    {
        using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
        consumer.Subscribe(_topic);
        logger.LogInformation("Kafka consumer subscribed to topic: {Topic}", _topic);

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                ConsumeResult<Ignore, string>? cr = null;
                try
                {
                    cr = consumer.Consume(cancellationToken);
                    logger.LogInformation("Message consumed: {Message}", cr.Message.Value);

                    var eventData = JsonConvert.DeserializeObject<CreateStudentEvent>(cr.Message.Value);

                    if (eventData?.Event == null)
                    {
                        logger.LogWarning("Received null or invalid event data: {Raw}", cr.Message.Value);
                        continue;
                    }

                    await repository.Create(eventData.Event);
                    logger.LogInformation("Student created successfully with ID: {Id}", eventData.Event.Id);

                    consumer.Commit(cr); // Commit offset only on success
                }
                catch (JsonException jsonEx)
                {
                    logger.LogError(jsonEx, "Failed to deserialize message: {Raw}", cr?.Message.Value);
                }
                catch (OperationCanceledException)
                {
                    logger.LogWarning("Kafka consumer task cancelled");
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error processing message");
                    // Decide here if you want to continue or break (could poison the queue).
                }
            }
        }
        finally
        {
            consumer.Close();
            logger.LogInformation("Kafka consumer closed gracefully.");
        }
    }
}

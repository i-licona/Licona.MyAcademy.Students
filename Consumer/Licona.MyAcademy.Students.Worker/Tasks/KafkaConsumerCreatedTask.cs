using Newtonsoft.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Licona.MyAcademy.Students.Domain.Settings;
using Licona.MyAcademy.Students.Domain.Entities.Events;
using Licona.MyAcademy.Students.Domain.Entities.Tables;
using Licona.MyAcademy.Students.Domain.Ports.Repositories;

namespace Licona.MyAcademy.Students.Worker.Tasks;

public class KafkaConsumerCreatedTask(
    IOptions<KafkaSettings> _kafkaSettings,
    IDatabaseRepository<Student> _repository
)
{
    public async Task ConsumeEvent(CancellationToken cancellationToken)
    {
        var config = new ConsumerConfig
        {
            GroupId = _kafkaSettings.Value.GroupId,
            BootstrapServers = $"{_kafkaSettings.Value.Hostname}:{_kafkaSettings.Value.Port}",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        string topic = nameof(CreateStudentEvent);
        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe(topic);
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var cr = consumer.Consume(cancellationToken);
                var data = JsonConvert.DeserializeObject<CreateStudentEvent>(cr.Message.Value);
                await _repository.Create(data.Event);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

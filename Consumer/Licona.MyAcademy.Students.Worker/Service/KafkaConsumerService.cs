
using Licona.MyAcademy.Students.Worker.Tasks;

namespace Licona.MyAcademy.Students.Worker.Service;

public class KafkaConsumerService(
    KafkaConsumerCreatedTask _consumerCreatedTask        
) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _consumerCreatedTask.ConsumeEvent(stoppingToken);
    }
}

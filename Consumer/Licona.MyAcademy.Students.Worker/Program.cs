using Licona.MyAcademy.Students.Worker.Tasks;
using Licona.MyAcademy.Students.Worker.Service;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<KafkaConsumerCreatedTask>();
builder.Services.AddHostedService<KafkaConsumerService>();

var host = builder.Build();
host.Run();

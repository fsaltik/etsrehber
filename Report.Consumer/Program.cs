using System.Text;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rehber.Infrastructure.Dtos;
using Rehber.Infrastructure.Enums;
using Rehber.Infrastructure.Interfaces;
using Rehber.Infrastructure.Repositories;

using Microsoft.Extensions.Configuration;
using Rehber.Infrastructure.Data;

// Build a config object, using env vars and JSON providers.
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

ServiceProvider serviceProvider = new ServiceCollection()
    .AddTransient<IReportQueuRepository,ReportQueuRepository>()
    .AddDbContext<DataContext>(option =>
            option.UseNpgsql(config.GetConnectionString("DefaultConnection")))
    .BuildServiceProvider();


var factory = new ConnectionFactory() {HostName = "localhost"};
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "rehber",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += async (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        var UUID = Guid.Empty;
        if (Guid.TryParse(message, out UUID))
        {
            IReportQueuRepository repo = serviceProvider.GetService<IReportQueuRepository>();
            
            var reportQueue=await repo.GetById(UUID);
            if (reportQueue != null)
            {
                reportQueue.State = TypeEnums.ReportState.Processing;
                await repo.Update(reportQueue);

                var result = await repo.GetReport();
                
                string json = JsonConvert.SerializeObject(result);
                reportQueue.UpdatedAt=DateTime.Now;
                reportQueue.State = TypeEnums.ReportState.Done;
                reportQueue.Result = Encoding.ASCII.GetBytes(json);
                await repo.Update(reportQueue);
            }
        }
    };
    channel.BasicConsume(queue: "rehber",
        autoAck: true,
        consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}
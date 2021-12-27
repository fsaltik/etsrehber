using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using Rehber.Infrastructure.Enums;
using Rehber.Infrastructure.Interfaces;
using Rehber.Infrastructure.Models;

namespace Rehber.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : Controller
{
    private readonly IReportQueuRepository _reportQueuRepository;

    public ReportController(IReportQueuRepository reportQueuRepository)
    {
        _reportQueuRepository = reportQueuRepository;
    }

    [HttpGet("QueuReport")]
    public async Task<JsonResult> QueuReport()
    {
        var reportQueu = new ReportQueu
        {
            UUID = Guid.NewGuid(),
            State =  TypeEnums.ReportState.Queued,
            CreatedAt = DateTime.Now
        };

        await _reportQueuRepository.Create(reportQueu);

        var factory = new ConnectionFactory() { HostName = "localhost" };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "rehber",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        
            var message = reportQueu.UUID.ToString();
            var body = Encoding.UTF8.GetBytes(message);
        
            channel.BasicPublish(exchange: "",
                routingKey: "rehber",
                basicProperties: null,
                body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }
        
        

        return new JsonResult(
            reportQueu.UUID,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            });
    }
}
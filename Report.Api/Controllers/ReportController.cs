using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rehber.Infrastructure.Interfaces;

namespace Report.Api.Controllers;

public class ReportController :Controller
{
    private readonly IReportQueuRepository _reportQueuRepository;

    public ReportController(IReportQueuRepository reportQueuRepository)
    {
        _reportQueuRepository = reportQueuRepository;
    }

    [HttpPost("getreportinfo")]
    public async Task<JsonResult> GetReportInfo(Guid id)
    {
        return new JsonResult(
            _reportQueuRepository.GetById(id),
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            });
    }

    [HttpGet("getall")]
    public async Task<JsonResult> GetAll()
    {
        return new JsonResult(
            _reportQueuRepository.GetAll(),
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            });
    }

}
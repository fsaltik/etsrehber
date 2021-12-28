using Rehber.Infrastructure.Dtos;
using Rehber.Infrastructure.Models;

namespace Rehber.Infrastructure.Interfaces;

public interface IReportQueuRepository : IRepository<ReportQueu>
{
    Task<ICollection<ReportDto>> GetReport();
}
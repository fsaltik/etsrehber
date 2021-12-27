using Rehber.Infrastructure.Data;
using Rehber.Infrastructure.Interfaces;
using Rehber.Infrastructure.Models;

namespace Rehber.Infrastructure.Repositories;

public class ReportQueuRepository:GenericRepository<ReportQueu> ,IReportQueuRepository
{
    public ReportQueuRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
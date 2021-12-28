using Microsoft.EntityFrameworkCore;
using Rehber.Infrastructure.Data;
using Rehber.Infrastructure.Dtos;
using Rehber.Infrastructure.Enums;
using Rehber.Infrastructure.Interfaces;
using Rehber.Infrastructure.Models;

namespace Rehber.Infrastructure.Repositories;

public class ReportQueuRepository:GenericRepository<ReportQueu> ,IReportQueuRepository
{
    private readonly DataContext _context;
    public ReportQueuRepository(DataContext dbContext, DataContext context) : base(dbContext)
    {
        _context = context;
    }

    public async Task<ICollection<ReportDto>> GetReport()
    {
        var query = from c in _context.Contacts
            group c by c.Location
            into g
            select new ReportDto
            {
                Location = g.Key, PersonCount =
                    _context.Contacts.Count(c =>
                        c.Location == g.Key),
                PhoneCount = _context.Contacts.Count(c =>
                    c.Location == g.Key && c.Type == TypeEnums.ContactType.Phone_Number)
            };

        var result =await query.ToListAsync();
        return result;
    }
}
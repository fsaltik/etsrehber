using Microsoft.EntityFrameworkCore;
using Rehber.Infrastructure.Data;
using Rehber.Infrastructure.Dtos;
using Rehber.Infrastructure.Interfaces;
using Rehber.Infrastructure.Models;

namespace Rehber.Infrastructure.Repositories;

public class PersonRepository :GenericRepository<Person>, IPersonRepository
{
    private readonly DataContext _context;
   
   public PersonRepository(DataContext dbContext) : base(dbContext)
   {
       _context = dbContext;
   }

    public async Task<Person> GetPersonAndContactsById(Guid id)
    {
        return await _context.Persons.Include(p => p.Contacts)
            .FirstOrDefaultAsync(p => p.UUID == id);
    }

    
}
using Rehber.Infrastructure.Data;
using Rehber.Infrastructure.Interfaces;
using Rehber.Infrastructure.Models;

namespace Rehber.Infrastructure.Repositories;

public class ContactRepository:GenericRepository<Contact> ,IContactRepository
{
    public ContactRepository(DataContext dbContext) : base(dbContext)
    {
    }
}
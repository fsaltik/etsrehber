using Rehber.Infrastructure.Dtos;
using Rehber.Infrastructure.Models;

namespace Rehber.Infrastructure.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task<Person> GetPersonAndContactsById(Guid id);
}
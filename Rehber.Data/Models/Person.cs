namespace Rehber.Infrastructure.Models;

public class Person : BaseEntity
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string CompanyName { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    
}
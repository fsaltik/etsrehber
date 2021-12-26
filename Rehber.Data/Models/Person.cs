namespace Rehber.Infrastructure.Models;

public class Person : BaseEntity
{
    public string Ad { get; set; }
    public string Name { get; set; }
    public string CompanyName { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    
}
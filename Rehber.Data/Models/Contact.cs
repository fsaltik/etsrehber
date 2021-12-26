using Rehber.Infrastructure.Enums;

namespace Rehber.Infrastructure.Models;

public class Contact :BaseEntity
{
    public Guid PersonUUID { get; set; }
    public TypeEnums.ContactType Type { get; set; }
    public string Detail { get; set; }
    public string Email { get; set; }
    public string Location { get; set; }
}
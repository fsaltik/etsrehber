using Rehber.Infrastructure.Enums;

namespace Rehber.Infrastructure.Models;

public class Contact :BaseEntity
{
    public TypeEnums.ContactType Type { get; set; }
    public string Detail { get; set; }
}
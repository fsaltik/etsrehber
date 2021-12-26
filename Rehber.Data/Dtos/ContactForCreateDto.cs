using Rehber.Infrastructure.Enums;

namespace Rehber.Infrastructure.Dtos;

public class ContactForCreateDto
{
    public Guid PersonId { get; set; }
    public TypeEnums.ContactType Type { get; set; }
    public string EMail { get; set; }
    public string Location { get; set; }
    public string Detail { get; set; }
}
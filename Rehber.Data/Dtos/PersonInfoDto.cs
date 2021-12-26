namespace Rehber.Infrastructure.Dtos;

public class PersonInfoDto
{
    public PersonForCreateDto PersonDto { get; set; }
    public ICollection<ContactForCreateDto> ContactDto { get; set; }
}
using AutoMapper;
using Rehber.Infrastructure.Dtos;
using Rehber.Infrastructure.Models;

namespace Rehber.Api.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Person, PersonForCreateDto>();
        CreateMap<Contact, ContactForCreateDto>();
    }
}
using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rehber.Api.Controllers;
using Xunit;
using Moq;
using Rehber.Infrastructure.Dtos;
using Rehber.Infrastructure.Interfaces;
using Newtonsoft.Json.Linq;  

namespace Rehber.Test;

public class PersonTest
{
    private readonly PersonController _controller;
    private readonly IPersonRepository _personRepo;
    private readonly IMapper _mapper;
    private readonly IContactRepository _contanctRepo;

    public PersonTest()
    {
        _personRepo = new Mock<IPersonRepository>().Object;
        _mapper = new Mock<IMapper>().Object;
        _contanctRepo = new Mock<IContactRepository>().Object;
        _controller = new PersonController(_personRepo, _mapper, _contanctRepo);
        //_controller = new PersonController(_personRepo, _mapper, _contanctRepo);
    }

    [Fact]
    public async Task Create_ReturnOk()
    {
        var personDto = new Mock<PersonForCreateDto>().Object;
        var result = _controller.Create(personDto);
        Assert.IsAssignableFrom<OkResult>(result.Result);
    }

    [Fact]
    public async Task RemovePerson_ReturnOk()
    {
        var UUID = new Guid("9885171c-b60d-4f37-9e5d-8a0e7bcb9bc5");
        var result = _controller.RemovePerson(UUID);
        Assert.IsAssignableFrom<OkResult>(result.Result);
    }

    [Fact]
    public async Task AddContactInfo_ReturnOk()
    {
        var contanctDto = new Mock<ContactForCreateDto>().Object;
        var result = _controller.AddContactInfo(contanctDto);
        Assert.IsAssignableFrom<OkResult>(result.Result);
    }

    [Fact]
    public async Task RemoveContactInfo_ReturnOk()
    {
        var UUID = new Guid("9885171c-b60d-4f37-9e5d-8a0e7bcb9bc5");
        var result = _controller.RemoveContactInfo(UUID);
        Assert.IsAssignableFrom<OkResult>(result.Result);
    }
    
    [Fact]
    public async Task getPersonInfo_ReturnJson()
    {
        var UUID = new Guid("9885171c-b60d-4f37-9e5d-8a0e7bcb9bc5");
        JsonResult result = await _controller.getPersonInfo(UUID);
        Assert.NotNull(result.Value);
    }
     [Fact]
        public async Task getAll_ReturnJson()
        {
            JsonResult result = await _controller.GetAll();
            Assert.NotNull(result.Value);
            dynamic jsonCollection = result.Value;
            foreach (dynamic json in jsonCollection)
            {
                Assert.NotNull(json.name);
                Assert.NotNull(json.type);
            } 
        }
        
    
}
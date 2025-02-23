using AutoMapper;
using ManagementSystem.Application.CQRS.Users.Responses;
using ManagementSystem.Application.CQRS.Users.ResponsesDtos;
using ManagementSystem.Domain.Entities;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using static ManagementSystem.Application.CQRS.Users.Handlers.Register;

namespace ManagementSystem.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Command, User>();
        CreateMap<User, RegisterDto>();
        CreateMap<User, UpdateDto>();

    }
}

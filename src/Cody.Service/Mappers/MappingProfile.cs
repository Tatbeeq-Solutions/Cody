using AutoMapper;
using Cody.Domain.Entities;
using Cody.Service.DTOs.Logins;
using Cody.Service.DTOs.Users;

namespace Cody.Service.Mappers;

public class MappingProfile : Profile
{
    public  MappingProfile()
    {
        CreateMap<UserCreateDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<User, UserResultDto>().ReverseMap();
    }
}

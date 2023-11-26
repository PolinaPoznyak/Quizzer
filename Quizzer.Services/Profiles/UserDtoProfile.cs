using AutoMapper;
using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Services.Profiles;

public class UserDtoProfile : Profile
{
    public UserDtoProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
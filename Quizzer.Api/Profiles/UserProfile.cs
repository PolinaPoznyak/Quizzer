using AutoMapper;
using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
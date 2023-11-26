using AutoMapper;
using Quizzer.Api.Models.Request.Users;
using Quizzer.Api.Models.Response.Users;
using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        
        CreateMap<UserCreateRequestModel, UserDto>();
        CreateMap<UserUpdateRequestModel, UserDto>();
        
        CreateMap<UserDto, UserCreateResponseModel>();
        CreateMap<UserDto, UserUpdateResponseModel>();
        CreateMap<UserDto, UserDeleteResponseModel>();
        CreateMap<UserDto, UserGetResponseModel>();
    }
}
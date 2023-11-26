using AutoMapper;
using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Services.Profiles;

public class QuizDtoProfile : Profile
{
    public QuizDtoProfile()
    {
        CreateMap<Quiz, QuizDto>().ReverseMap();
    }
}
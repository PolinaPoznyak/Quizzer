using AutoMapper;
using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Services.Profiles;

public class QuizSessionDtoProfile : Profile
{
    public QuizSessionDtoProfile()
    {
        CreateMap<QuizSession, QuizSessionDto>().ReverseMap();
    }  
}
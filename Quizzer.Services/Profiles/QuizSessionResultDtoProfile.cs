using AutoMapper;
using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Services.Profiles;

public class QuizSessionResultDtoProfile : Profile
{
    public QuizSessionResultDtoProfile()
    {
        CreateMap<QuizSessionResult, QuizSessionResultDto>().ReverseMap();
    }  
}
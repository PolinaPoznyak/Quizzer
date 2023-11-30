using AutoMapper;
using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Services.Profiles;

public class QuizAnswerDtoProfile : Profile
{
    public QuizAnswerDtoProfile()
    {
        CreateMap<QuizAnswer, QuizAnswerDto>().ReverseMap();
    }
}
using AutoMapper;
using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Services.Profiles;

public class QuestionDtosProfile : Profile
{
    public QuestionDtosProfile()
    {
        CreateMap<Question, QuestionDto>().ReverseMap();
    }    
}
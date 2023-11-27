using AutoMapper;
using Quizzer.Api.Models.Request.Quiz;
using Quizzer.Api.Models.Response.Quiz;
using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Api.Profiles;

public class QuizProfile : Profile
{
    public QuizProfile()
    {
        CreateMap<Quiz, QuizDto>().ReverseMap();
        
        CreateMap<QuizCreateRequestModel, QuizDto>();
        CreateMap<QuizUpdateRequestModel, QuizDto>();
        
        CreateMap<QuizDto, QuizCreateResponseModel>();
        CreateMap<QuizDto, QuizUpdateResponseModel>();
        CreateMap<QuizDto, QuizDeleteResponseModel>();
        CreateMap<QuizDto, QuizGetResponseModel>();
    }
}
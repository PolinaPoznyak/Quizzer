using AutoMapper;
using Quizzer.Api.Models.Request.QuizSession;
using Quizzer.Api.Models.Response.QuizSession;
using Quizzer.Dtos;

namespace Quizzer.Api.Profiles;

public class QuizSessionProfile : Profile
{
    public QuizSessionProfile()
    {
        CreateMap<QuizSessionCreateRequestModel, QuizSessionDto>();
        CreateMap<QuizSessionUpdateRequestModel, QuizSessionDto>();
        
        CreateMap<QuizSessionDto, QuizSessionCreateResponseModel>();
        CreateMap<QuizSessionDto, QuizSessionUpdateResponseModel>();
        CreateMap<QuizSessionDto, QuizSessionDeleteResponseModel>();
        CreateMap<QuizSessionDto, QuizSessionGetResponseModel>();
    }    
}
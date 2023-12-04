using AutoMapper;
using Quizzer.Api.Models.Request.QuizSessionResult;
using Quizzer.Api.Models.Response.QuizSessionResult;
using Quizzer.Dtos;

namespace Quizzer.Api.Profiles;

public class QuizSessionResultProfile : Profile
{
    public QuizSessionResultProfile()
    {
        CreateMap<QuizSessionResultCreateRequestModel, QuizSessionResultDto>();
        CreateMap<QuizSessionResultUpdateRequestModel, QuizSessionResultDto>();
        
        CreateMap<QuizSessionResultDto, QuizSessionResultCreateResponseModel>();
        CreateMap<QuizSessionResultDto, QuizSessionResultUpdateResponseModel>();
        CreateMap<QuizSessionResultDto, QuizSessionResultDeleteResponseModel>();
        CreateMap<QuizSessionResultDto, QuizSessionResultGetResponseModel>();
    }    
}
using AutoMapper;
using Quizzer.Api.Models.Request.Questions;
using Quizzer.Api.Models.Response.Questions;
using Quizzer.Dtos;

namespace Quizzer.Api.Profiles;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<QuestionCreateRequestModel, QuestionDto>();
        CreateMap<QuestionUpdateRequestModel, QuestionDto>();
        
        CreateMap<QuestionDto, QuestionCreateResponseModel>();
        CreateMap<QuestionDto, QuestionUpdateRequestModel>();
        CreateMap<QuestionDto, QuestionDeleteResponseModel>();
        CreateMap<QuestionDto, QuestionGetResponseModel>();
    }    
}
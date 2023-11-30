using AutoMapper;
using Quizzer.Api.Models.Request.QuizAnswer;
using Quizzer.Api.Models.Response.QuizAnswer;
using Quizzer.Dtos;

namespace Quizzer.Api.Profiles;

public class QuizAnswerProfile : Profile
{
    public QuizAnswerProfile()
    {
        CreateMap<QuizAnswerCreateRequestModel, QuizAnswerDto>();
        CreateMap<QuizAnswerUpdateRequestModel, QuizAnswerDto>();
        
        CreateMap<QuizAnswerDto, QuizAnswerCreateResponseModel>();
        CreateMap<QuizAnswerDto, QuizAnswerUpdateResponseModel>();
        CreateMap<QuizAnswerDto, QuizAnswerDeleteResponseModel>();
        CreateMap<QuizAnswerDto, QuizAnswerGetResponseModel>();
    }
}
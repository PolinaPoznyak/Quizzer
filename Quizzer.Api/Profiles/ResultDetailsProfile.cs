using AutoMapper;
using Quizzer.Api.Models.Request.ResultDetails;
using Quizzer.Api.Models.Response.ResultDetails;
using Quizzer.Dtos;

namespace Quizzer.Api.Profiles;

public class ResultDetailsProfile : Profile
{
    public ResultDetailsProfile()
    {
        CreateMap<ResultDetailsCreateRequestModel, ResultDetailsDto>();
        CreateMap<ResultDetailsUpdateRequestModel, ResultDetailsDto>();
        
        CreateMap<ResultDetailsDto, ResultDetailsCreateResponseModel>();
        CreateMap<ResultDetailsDto, ResultDetailsUpdateResponseModel>();
        CreateMap<ResultDetailsDto, ResultDetailsDeleteResponseModel>();
        CreateMap<ResultDetailsDto, ResultDetailsGetResponseModel>();
    }    
}
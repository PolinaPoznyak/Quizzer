using AutoMapper;
using Quizzer.Dtos;
using Quizzer.Entities;

namespace Quizzer.Services.Profiles;

public class ResultDetailsDtoProfile : Profile
{
    public ResultDetailsDtoProfile()
    {
        CreateMap<ResultDetails, ResultDetailsDto>().ReverseMap();
    }  
}
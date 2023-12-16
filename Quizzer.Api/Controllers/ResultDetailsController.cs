using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizzer.Api.Models.Request.ResultDetails;
using Quizzer.Api.Models.Response.ResultDetails;
using Quizzer.Dtos;
using Quizzer.Services.Interfaces;

namespace Quizzer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResultDetailsController : ControllerBase
{
    private readonly IResultDetailsService _resultDetailsService;
    private readonly IMapper _mapper;
        
        
    public ResultDetailsController(IResultDetailsService resultDetailsService, IMapper mapper)
    {
        _resultDetailsService = resultDetailsService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateResultDetail(ResultDetailsCreateRequestModel resultDetailsRequest)
    {
        var resultDetailsDto = _mapper.Map<ResultDetailsDto>(resultDetailsRequest);
        var resultDetails = await _resultDetailsService.CreateResultDetailAsync(resultDetailsDto);
        var resultDetailsResponse = _mapper.Map<ResultDetailsCreateResponseModel>(resultDetails);
    
        return Ok(resultDetailsResponse);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateResultDetail(ResultDetailsUpdateRequestModel resultDetailsRequest)
    {
        var resultDetailsDto = _mapper.Map<ResultDetailsDto>(resultDetailsRequest);
        var resultDetails = await _resultDetailsService.UpdateResultDetailAsync(resultDetailsDto);
        var resultDetailsResponse = _mapper.Map<ResultDetailsUpdateResponseModel>(resultDetails);
    
        return Ok(resultDetailsResponse);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteResultDetail(Guid id)
    {
        var resultDetailsDto = await _resultDetailsService.DeleteResultDetailAsync(id);
        var resultDetailsResponse = _mapper.Map<ResultDetailsDeleteResponseModel>(resultDetailsDto);

        return Ok(resultDetailsResponse);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetResultDetailById(Guid id)
    {
        var resultDetailsDto = await _resultDetailsService.GetResultDetailByIdAsync(id);
        var resultDetailsResponse = _mapper.Map<ResultDetailsGetResponseModel>(resultDetailsDto);

        return Ok(resultDetailsResponse);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllResultDetails()
    {
        var resultDetailsDtos = await _resultDetailsService.GetAllResultDetailsAsync();
        var resultDetailsResponse = resultDetailsDtos.Select(resultDetailsDto => _mapper.Map<ResultDetailsGetResponseModel>(resultDetailsDto));

        return Ok(resultDetailsResponse);
    }
    
    [HttpGet("result/{quizSessionResultId:guid}")]
    public async Task<IActionResult> GetAllResultDetailsByResultDetails(Guid quizSessionResultId)
    {
        var resultDetailsDtos = await _resultDetailsService.GetAllResultDetailsByResulAsync(quizSessionResultId);
        var resultDetailsResponse = resultDetailsDtos.Select(resultDetailsDto => _mapper.Map<ResultDetailsGetResponseModel>(resultDetailsDto));

        return Ok(resultDetailsResponse);
    }
}
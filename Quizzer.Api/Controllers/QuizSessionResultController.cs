using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizzer.Api.Models.Request.QuizSessionResult;
using Quizzer.Api.Models.Response.QuizSessionResult;
using Quizzer.Dtos;
using Quizzer.Services.Interfaces;

namespace Quizzer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizSessionResultController : ControllerBase
{
    private readonly IQuizSessionResultService _quizSessionResultService;
    private readonly IMapper _mapper;
        
        
    public QuizSessionResultController(IQuizSessionResultService quizSessionResultService, IMapper mapper)
    {
        _quizSessionResultService = quizSessionResultService;
        _mapper = mapper;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateQuizSession(QuizSessionResultCreateRequestModel quizSessionResultRequest)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.Name);

        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
        {
            return BadRequest("Invalid user ID");
        }
        var quizSessionResultDto = _mapper.Map<QuizSessionResultDto>(quizSessionResultRequest);

        quizSessionResultDto.UserId = userId;
        
        var quizSessionResult = await _quizSessionResultService.CreateQuizSessionResultAsync(quizSessionResultDto);
        var quizSessionResultResponse = _mapper.Map<QuizSessionResultCreateResponseModel>(quizSessionResult);
    
        return Ok(quizSessionResultResponse);
    }
    
    [Authorize]
    [HttpPost("multiplayer-quiz")]
    public async Task<IActionResult> CreateQuizSessionResultByQuizCode(int quizCode)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.Name);

        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
        {
            return BadRequest("Invalid user ID");
        }
        var quizSessionResult = await _quizSessionResultService.CreateQuizSessionResultByCodeAsync(quizCode, userId);
        var quizSessionResultResponse = _mapper.Map<QuizSessionResultCreateResponseModel>(quizSessionResult);
    
        return Ok(quizSessionResultResponse);
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateResultDetail(QuizSessionResultUpdateRequestModel resultDetailsRequest)
    {
        var quizSessionResultDto = _mapper.Map<QuizSessionResultDto>(resultDetailsRequest);
        var quizSessionResult = await _quizSessionResultService.UpdateQuizSessionResultAsync(quizSessionResultDto);
        var quizSessionResultResponse = _mapper.Map<QuizSessionResultUpdateResponseModel>(quizSessionResult);
    
        return Ok(quizSessionResultResponse);
    }
     
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteQuizSessionResult(Guid id)
    {
        var quizSessionResultDto = await _quizSessionResultService.DeleteQuizSessionResultAsync(id);
        var quizSessionResultResponse = _mapper.Map<QuizSessionResultDeleteResponseModel>(quizSessionResultDto);

        return Ok(quizSessionResultResponse);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetQuizSessionResultById(Guid id)
    {
        var quizSessionResultDto = await _quizSessionResultService.GetQuizSessionResultByIdAsync(id);
        var quizSessionResultResponse = _mapper.Map<QuizSessionResultGetResponseModel>(quizSessionResultDto);
    
        return Ok(quizSessionResultResponse);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetQuizSessionResults()
    {
        var quizSessionResultDtos = await _quizSessionResultService.GetAllQuizSessionResultsAsync();
        var quizSessionResultResponse = quizSessionResultDtos.Select(quizSessionResultDto => _mapper.Map<QuizSessionResultGetResponseModel>(quizSessionResultDto));
    
        return Ok(quizSessionResultResponse);
    }
}
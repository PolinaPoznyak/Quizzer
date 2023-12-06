using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizzer.Api.Models.Request.QuizSession;
using Quizzer.Api.Models.Response.QuizSession;
using Quizzer.Dtos;
using Quizzer.Services.Interfaces;

namespace Quizzer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizSessionController : ControllerBase
{
    private readonly IQuizSessionService _quizSessionService;
    private readonly IMapper _mapper;
        
        
    public QuizSessionController(IQuizSessionService quizSessionService, IMapper mapper)
    {
        _quizSessionService = quizSessionService;
        _mapper = mapper;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateQuizSession(QuizSessionCreateRequestModel quizSessionRequest)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.Name);

        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
        {
            return BadRequest("Invalid user ID");
        }
        
        var quizSessionDto = _mapper.Map<QuizSessionDto>(quizSessionRequest);

        quizSessionDto.QuizSessionResults.FirstOrDefault().UserId = userId;
            
        var quizSession = await _quizSessionService.CreateQuizSessionAsync(quizSessionDto);
        var quizSessionResponse = _mapper.Map<QuizSessionCreateResponseModel>(quizSession);

        return Ok(quizSessionResponse);
    }
    
    
    [HttpPut]
    public async Task<IActionResult> UpdateQuizSession(QuizSessionUpdateRequestModel quizSessionRequest)
    {
        var quizSessionDto = _mapper.Map<QuizSessionDto>(quizSessionRequest);
        var quizSession = await _quizSessionService.UpdateQuizSessionAsync(quizSessionDto);
        var quizSessionResponse = _mapper.Map<QuizSessionCreateResponseModel>(quizSession);

        return Ok(quizSessionResponse);
    } 

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteQuizSession(Guid id)
    {
        var quizSessionDto = await _quizSessionService.DeleteQuizSessionAsync(id);
        var quizSessionResponse = _mapper.Map<QuizSessionDeleteResponseModel>(quizSessionDto);

        return Ok(quizSessionResponse);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetQuizSessionById(Guid id)
    {
        var quizSessionDto = await _quizSessionService.GetQuizSessionByIdAsync(id);
        var quizSessionResponse = _mapper.Map<QuizSessionGetResponseModel>(quizSessionDto);

        return Ok(quizSessionResponse);
    }
    
    [HttpGet("quiz/{quizId:guid}")]
    public async Task<IActionResult> GetQuizSessionsByQuizId(Guid quizId)
    {
        var quizSessionDtos = await _quizSessionService.GetQuizSessionByQuizIdAsync(quizId);
        var quizSessionResponse = quizSessionDtos.Select(quizSessionDto => _mapper.Map<QuizSessionGetResponseModel>(quizSessionDto));

        return Ok(quizSessionResponse);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllQuizSessions()
    {
        var quizSessionDtos = await _quizSessionService.GetAllQuizSessionsAsync();
        var quizSessionResponse = quizSessionDtos.Select(quizSessionDto => _mapper.Map<QuizSessionGetResponseModel>(quizSessionDto));

        return Ok(quizSessionResponse);
    }
}
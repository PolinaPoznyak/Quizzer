using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizzer.Api.Models.Request.QuizAnswer;
using Quizzer.Api.Models.Response.QuizAnswer;
using Quizzer.Dtos;
using Quizzer.Services.Interfaces;

namespace Quizzer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizAnswerController : ControllerBase
{
    private readonly IQuizAnswerService _quizAnswerService;
    private readonly IMapper _mapper;

    public QuizAnswerController(IQuizAnswerService quizAnswerService, IMapper mapper)
    {
        _quizAnswerService = quizAnswerService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateQuizAnswer(QuizAnswerCreateRequestModel quizAnswerRequest)
    {
        var quizAnswerDto = _mapper.Map<QuizAnswerDto>(quizAnswerRequest);
        var quizAnswer = await _quizAnswerService.CreateQuizAnswerAsync(quizAnswerDto);
        var quizAnswerResponse = _mapper.Map<QuizAnswerCreateResponseModel>(quizAnswer);

        return Ok(quizAnswerResponse);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateQuizAnswer(QuizAnswerUpdateRequestModel quizAnswerRequest)
    {
        var quizAnswerDto = _mapper.Map<QuizAnswerDto>(quizAnswerRequest);
        var quizAnswer = await _quizAnswerService.UpdateQuizAnswerAsync(quizAnswerDto);
        var quizAnswerResponse = _mapper.Map<QuizAnswerUpdateResponseModel>(quizAnswer);

        return Ok(quizAnswerResponse);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteQuizAnswer(Guid id)
    {
        var quizAnswerDto = await _quizAnswerService.DeleteQuizAnswerAsync(id);
        var quizAnswerResponse = _mapper.Map<QuizAnswerDeleteResponseModel>(quizAnswerDto);

        return Ok(quizAnswerResponse);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetQuizAnswerById(Guid id)
    {
        var quizAnswerDto = await _quizAnswerService.GetQuizAnswerByIdAsync(id);
        var quizAnswerResponse = _mapper.Map<QuizAnswerGetResponseModel>(quizAnswerDto);

        return Ok(quizAnswerResponse);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllQuizAnswers()
    {
        var quizAnswerDtos = await _quizAnswerService.GetAllQuizAnswersAsync();
        var quizAnswerResponse = quizAnswerDtos.Select(quizAnswerDto => _mapper.Map<QuizAnswerGetResponseModel>(quizAnswerDto));

        return Ok(quizAnswerResponse);
    }
}
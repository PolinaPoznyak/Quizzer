using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizzer.Api.Models.Request.Quiz;
using Quizzer.Api.Models.Response.Quiz;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Services.Interfaces;

namespace Quizzer.Api.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        
        private readonly IMapper _mapper;
        
        
        public QuizController(IQuizService quizService, IMapper mapper)
        {
            _quizService = quizService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateQuiz(QuizCreateRequestModel quizRequest)
        {
            var quizDto = _mapper.Map<QuizDto>(quizRequest);

            var quiz = await _quizService.CreateQuizAnsync(quizDto);
            var quizResponse = _mapper.Map<QuizCreateResponseModel>(quiz);

            return Ok(quizResponse);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateQuiz(QuizUpdateRequestModel quizRequest)
        {
            var existingQuiz = await _quizService.GetQuizByIdAsync(quizRequest.Id);

            if (existingQuiz == null)
            {
                return NotFound($"Quiz with Id {quizRequest.Id} not found.");
            }
            var updatedQuizDto = _mapper.Map<QuizDto>(quizRequest);
            var updatedQuiz = await _quizService.UpdateQuizAsync(updatedQuizDto);
            var quizResponse = _mapper.Map<QuizUpdateResponseModel>(updatedQuiz);

            return Ok(quizResponse);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            var quizDto = await _quizService.DeleteQuizAsync(id);
            var quizResponse = _mapper.Map<QuizDeleteResponseModel>(quizDto);

            return Ok(quizResponse);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetQuizById(Guid id)
        {
            var quizDto = await _quizService.GetQuizByIdAsync(id);
            var quizResponse = _mapper.Map<QuizGetResponseModel>(quizDto);

            return Ok(quizResponse);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetQuizzes()
        {
            var quizDtos = await _quizService.GetAllQuizzesAsync();

            var quizResponse = quizDtos.Select(quizDto => _mapper.Map<QuizGetResponseModel>(quizDto));

            return Ok(quizResponse);
        }
    }
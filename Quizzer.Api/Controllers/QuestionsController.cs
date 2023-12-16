using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizzer.Api.Models.Request.Questions;
using Quizzer.Api.Models.Response.Questions;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Services.Interfaces;

namespace Quizzer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        
        private readonly IMapper _mapper;
        

        public QuestionsController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(QuestionCreateRequestModel questionRequest)
        {
            var questionDto = _mapper.Map<QuestionDto>(questionRequest);

            var question = await _questionService.CreateQuestionAsync(questionDto);
            var questionResponse = _mapper.Map<QuestionCreateResponseModel>(question);

            return Ok(questionResponse);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuestion(QuestionUpdateRequestModel questionRequest)
        {
            var questionDto = _mapper.Map<QuestionDto>(questionRequest);
            var question = await _questionService.UpdateQuestionAsync(questionDto);
            var questionResponse = _mapper.Map<QuestionUpdateResponseModel>(question);

            return Ok(questionResponse);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            var questionDto = await _questionService.DeleteQuestionAsync(id);
            var questionResponse = _mapper.Map<QuestionDeleteResponseModel>(questionDto);

            return Ok(questionResponse);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetQuestionById(Guid id)
        {
            var questionDto = await _questionService.GetQuestionByIdAsync(id);
            var questionResponse = _mapper.Map<QuestionGetResponseModel>(questionDto);

            return Ok(questionResponse);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var questionsDtos = await _questionService.GetAllQuestionsAsync();

            var questionsResponse = questionsDtos.Select(questionsDto => _mapper.Map<QuestionGetResponseModel>(questionsDto));

            return Ok(questionsResponse);
        }
    }
}

using AutoMapper;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Entities;
using Quizzer.Services.Interfaces;

namespace Quizzer.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;

    private readonly IMapper _mapper;

    
    public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    
    public async Task<QuestionDto> CreateQuestionAsync(QuestionDto questionDto)
    {
        var questionEntity = _mapper.Map<Question>(questionDto);
        await _questionRepository.CreateAsync(questionEntity);
        questionDto = _mapper.Map<QuestionDto>(questionEntity);

        return questionDto;
    }

    public async Task<QuestionDto> UpdateQuestionAsync(QuestionDto questionDto)
    {
        var questionEntity = _mapper.Map<Question>(questionDto);
        await _questionRepository.UpdateAsync(questionEntity);
        questionDto = _mapper.Map<QuestionDto>(questionEntity);

        return questionDto;
    }

    public async Task<QuestionDto> DeleteQuestionAsync(Guid id)
    {
        var question = await _questionRepository.GetByIdAsync(id);
        
        if (question == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        question = await _questionRepository.DeleteAsync(question);

        var questionDto = _mapper.Map<QuestionDto>(question);
        
        return questionDto;
    }

    public async Task<QuestionDto> GetQuestionByIdAsync(Guid id)
    {
        var question = await _questionRepository.GetByIdAsync(id);
        
        if (question == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        var questionDto = _mapper.Map<QuestionDto>(question);

        return questionDto;
    }
}
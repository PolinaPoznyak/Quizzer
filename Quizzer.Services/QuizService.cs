using AutoMapper;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Entities;
using Quizzer.Services.Interfaces;

namespace Quizzer.Services;

public class QuizService : IQuizService
{
    private readonly IQuizRepository _quizRepository;

    private readonly IMapper _mapper;

    public QuizService(IQuizRepository quizRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
    }
    
    public async Task<QuizDto> CreateQuizAnsync(QuizDto quizDto)
    {
        var quizEntity = _mapper.Map<Quiz>(quizDto);
        await _quizRepository.CreateAsync(quizEntity);
        quizDto = _mapper.Map<QuizDto>(quizEntity);

        return quizDto;
    }

    public async Task<QuizDto> UpdateQuizAsync(QuizDto quizDto)
    {
        var existingQuiz = await _quizRepository.GetQuizByIdAsync(quizDto.Id);

        if (existingQuiz == null)
        {
            return null;
        }

        existingQuiz.Title = quizDto.Title;
        existingQuiz.Description = quizDto.Description;
        
        await _quizRepository.UpdateAsync(existingQuiz);

        return quizDto;
    }

    public async Task<QuizDto> DeleteQuizAsync(Guid id)
    {
        var quiz = await _quizRepository.GetQuizByIdAsync(id);
        
        if (quiz == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        quiz = await _quizRepository.DeleteAsync(quiz);

        var quizDto = _mapper.Map<QuizDto>(quiz);
        
        return quizDto;
    }

    public async Task<IReadOnlyCollection<QuizDto>> GetAllQuizzesAsync()
    {
        var quizzes = await _quizRepository.GetAllQuizzesAsync();
        
        if (quizzes == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        var quizDtos = _mapper.Map<IReadOnlyCollection<QuizDto>>(quizzes);

        return quizDtos;
    }

    public async Task<QuizDto> GetQuizByIdAsync(Guid id)
    {
        var quiz = await _quizRepository.GetQuizByIdAsync(id);
        
        if (quiz == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        var quizDto = _mapper.Map<QuizDto>(quiz);

        return quizDto;
    }
}
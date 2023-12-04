using AutoMapper;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Entities;
using Quizzer.Services.Interfaces;

namespace Quizzer.Services;

public class QuizSessionService : IQuizSessionService
{
    private readonly IQuizSessionRepository _quizSessionRepository;
    private readonly IMapper _mapper;

    
    public QuizSessionService(IQuizSessionRepository quizSessionRepository, IMapper mapper)
    {
        _quizSessionRepository = quizSessionRepository;
        _mapper = mapper;
    }
    
    public async Task<QuizSessionDto> CreateQuizSessionAsync(QuizSessionDto quizSessionDto)
    {
        var quizSessionEntity = _mapper.Map<QuizSession>(quizSessionDto);
        await _quizSessionRepository.CreateAsync(quizSessionEntity);
        quizSessionDto = _mapper.Map<QuizSessionDto>(quizSessionEntity);

        return quizSessionDto;
    }

    public async Task<QuizSessionDto> UpdateQuizSessionAsync(QuizSessionDto quizSessionDto)
    {
        var quizSessionEntity = _mapper.Map<QuizSession>(quizSessionDto);
        await _quizSessionRepository.UpdateAsync(quizSessionEntity);
        quizSessionDto = _mapper.Map<QuizSessionDto>(quizSessionEntity);

        return quizSessionDto;
    }

    public async Task<QuizSessionDto> DeleteQuizSessionAsync(Guid id)
    {
        var quizSession = await _quizSessionRepository.GetByIdAsync(id);
        quizSession = await _quizSessionRepository.DeleteAsync(quizSession);
        var quizSessionDto = _mapper.Map<QuizSessionDto>(quizSession);
        
        return quizSessionDto;
    }

    public async Task<QuizSessionDto> GetQuizSessionByIdAsync(Guid id)
    {
        var quizSession = await _quizSessionRepository.GetByIdAsync(id);
        var quizSessionDto = _mapper.Map<QuizSessionDto>(quizSession);
        
        return quizSessionDto;
    }

    public async Task<IReadOnlyCollection<QuizSessionDto>> GetQuizSessionByQuizIdAsync(Guid id)
    {
        var quizSession = await _quizSessionRepository.GetQuizSessionByQuizIdAsync(id);
        var quizSessionDto = _mapper.Map<IReadOnlyCollection<QuizSessionDto>>(quizSession);
        
        return quizSessionDto;
    }

    public async  Task<IReadOnlyCollection<QuizSessionDto>> GetAllQuizSessionsAsync()
    {
        var quizSessions = await _quizSessionRepository.GetAllQuizSessionsAsync();
        
        if (quizSessions == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        var quizSessionsDtos = _mapper.Map<IReadOnlyCollection<QuizSessionDto>>(quizSessions);

        return quizSessionsDtos;
    }
}
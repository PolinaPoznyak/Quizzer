using AutoMapper;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Entities;
using Quizzer.Services.Interfaces;

namespace Quizzer.Services;

public class QuizSessionResultService : IQuizSessionResultService
{
    private readonly IQuizSessionResultRepository _quizSessionResultRepository;
    private readonly IMapper _mapper;

    
    public QuizSessionResultService(IQuizSessionResultRepository quizSessionResultRepository, IMapper mapper)
    {
        _quizSessionResultRepository = quizSessionResultRepository;
        _mapper = mapper;
    }
   
    public async Task<QuizSessionResultDto> CreateQuizSessionResultAsync(QuizSessionResultDto quizSessionResultDto)
    {
        var quizSessionResultEntity = _mapper.Map<QuizSessionResult>(quizSessionResultDto);
        await _quizSessionResultRepository.CreateAsync(quizSessionResultEntity);
        quizSessionResultDto = _mapper.Map<QuizSessionResultDto>(quizSessionResultEntity);

        return quizSessionResultDto;
    }

    public async Task<QuizSessionResultDto> UpdatQuizSessionResultAsync(QuizSessionResultDto quizSessionResultDto)
    {
        var quizSessionResultEntity = _mapper.Map<QuizSessionResult>(quizSessionResultDto);
        await _quizSessionResultRepository.UpdateAsync(quizSessionResultEntity);
        quizSessionResultDto = _mapper.Map<QuizSessionResultDto>(quizSessionResultEntity);

        return quizSessionResultDto;
    }
    
    public async Task<QuizSessionResultDto> UpdateQuizSessionResultAsync(QuizSessionResultDto quizSessionResultDto)
    {
        var quizSessionResultEntity = await _quizSessionResultRepository.GetResultByIdWithDetailsAsync(quizSessionResultDto.Id);
    
        if (quizSessionResultEntity != null)
        {
            int score = quizSessionResultEntity.ResultDetails.Count(rd => rd.IsCorrect == 1);
            quizSessionResultEntity.Score = score;

            await _quizSessionResultRepository.UpdateAsync(quizSessionResultEntity);
            quizSessionResultDto = _mapper.Map<QuizSessionResultDto>(quizSessionResultEntity);
        }

        return quizSessionResultDto;
    }

    public async Task<QuizSessionResultDto> DeleteQuizSessionResultAsync(Guid id)
    {
        var quizSessionResult = await _quizSessionResultRepository.GetByIdAsync(id);
        quizSessionResult = await _quizSessionResultRepository.DeleteAsync(quizSessionResult);
        var quizSessionResultDto = _mapper.Map<QuizSessionResultDto>(quizSessionResult);

        return quizSessionResultDto;
    }

    public async Task<QuizSessionResultDto> GetQuizSessionResultByIdAsync(Guid id)
    {
        var quizSessionResult = await _quizSessionResultRepository.GetByIdAsync(id);
        var quizSessionResultDto = _mapper.Map<QuizSessionResultDto>(quizSessionResult);
        
        return quizSessionResultDto;
    }

    public async Task<IReadOnlyCollection<QuizSessionResultDto>> GetAllQuizSessionResultsAsync()
    {
        var quizSessionResult = await _quizSessionResultRepository.GetAllQuizSessionResultAsync();
        var quizSessionResultDto = _mapper.Map<IReadOnlyCollection<QuizSessionResultDto>>(quizSessionResult);
        
        return quizSessionResultDto;
    }
}
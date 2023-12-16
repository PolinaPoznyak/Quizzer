using AutoMapper;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Entities;
using Quizzer.Services.Interfaces;

namespace Quizzer.Services;

public class ResultDetailsService : IResultDetailsService
{
    private readonly IResultDetailsRepository _resultDetailsRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuizAnswerRepository _quizAnswerRepository;
    private readonly IMapper _mapper;

    
    public ResultDetailsService(IResultDetailsRepository resultDetailsRepository, IQuestionRepository questionRepository, IQuizAnswerRepository quizAnswerRepository, IMapper mapper)
    {
        _resultDetailsRepository = resultDetailsRepository;
        _questionRepository = questionRepository;
        _quizAnswerRepository = quizAnswerRepository;
        _mapper = mapper;
    }
    
    public async Task<ResultDetailsDto> CreateResultDetailAsync(ResultDetailsDto resultDetailDto)
    {
        var question = await _questionRepository.GetByIdAsync(resultDetailDto.QuestionId);
        var isCorrectAnswer = question.Answers.Any(a => a.Id == resultDetailDto.QuizAnswerId && a.IsCorrect);

        var resultDetailsEntity = _mapper.Map<ResultDetails>(resultDetailDto);
        resultDetailsEntity.IsCorrect = isCorrectAnswer ? 1 : 0;
        await _resultDetailsRepository.CreateAsync(resultDetailsEntity);

        resultDetailDto = _mapper.Map<ResultDetailsDto>(resultDetailsEntity);
        return resultDetailDto;
    }
    
    public async Task<ResultDetailsDto> UpdateResultDetailAsync(ResultDetailsDto resultDetailDto)
    {
        var resultDetailEntity = _mapper.Map<ResultDetails>(resultDetailDto);
        await _resultDetailsRepository.UpdateAsync(resultDetailEntity);
        resultDetailDto = _mapper.Map<ResultDetailsDto>(resultDetailEntity);

        return resultDetailDto;
    }

    public async Task<ResultDetailsDto> DeleteResultDetailAsync(Guid id)
    {
        var resultDetail = await _resultDetailsRepository.GetByIdAsync(id);
        resultDetail = await _resultDetailsRepository.DeleteAsync(resultDetail);
        var resultDetailDto = _mapper.Map<ResultDetailsDto>(resultDetail);

        return resultDetailDto;
    }

    public async Task<ResultDetailsDto> GetResultDetailByIdAsync(Guid id)
    {
        var resultDetail = await _resultDetailsRepository.GetByIdAsync(id);
        var resultDetailDto = _mapper.Map<ResultDetailsDto>(resultDetail);
        
        return resultDetailDto;
    }

    public async Task<IReadOnlyCollection<ResultDetailsDto>> GetAllResultDetailsByResulAsync(Guid quizSessionResultId)
    {
        var resultDetails = await _resultDetailsRepository.GetByQuizSessionResultIdAsync(quizSessionResultId);
        var resultDetailsDto = _mapper.Map<IReadOnlyCollection<ResultDetailsDto>>(resultDetails);
        
        return resultDetailsDto;
    }
    
    public async Task<IReadOnlyCollection<ResultDetailsDto>> GetAllResultDetailsAsync()
    {
        var resultDetails = await _resultDetailsRepository.GetAllResultDetailsAsync();
        var resultDetailsDto = _mapper.Map<IReadOnlyCollection<ResultDetailsDto>>(resultDetails);
        
        return resultDetailsDto;
    }
}
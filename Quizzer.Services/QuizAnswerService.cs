using AutoMapper;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Entities;
using Quizzer.Services.Interfaces;

namespace Quizzer.Services;

public class QuizAnswerService: IQuizAnswerService
{
    private readonly IQuizAnswerRepository _quizAnswerRepository;
    private readonly IMapper _mapper;

    public QuizAnswerService(IQuizAnswerRepository quizAnswerRepository, IMapper mapper)
    {
        _quizAnswerRepository = quizAnswerRepository;
        _mapper = mapper;
    }

    public async Task<QuizAnswerDto> CreateQuizAnswerAsync(QuizAnswerDto quizAnswerDto)
    {
        var quizAnswerEntity = _mapper.Map<QuizAnswer>(quizAnswerDto);
        await _quizAnswerRepository.CreateAsync(quizAnswerEntity);
        quizAnswerDto = _mapper.Map<QuizAnswerDto>(quizAnswerEntity);

        return quizAnswerDto;
    }

    public async Task<QuizAnswerDto> UpdateQuizAnswerAsync(QuizAnswerDto quizAnswerDto)
    {
        var quizAnswerEntity = _mapper.Map<QuizAnswer>(quizAnswerDto);
        await _quizAnswerRepository.UpdateAsync(quizAnswerEntity);
        quizAnswerDto = _mapper.Map<QuizAnswerDto>(quizAnswerEntity);

        return quizAnswerDto;
    }

    public async Task<QuizAnswerDto> DeleteQuizAnswerAsync(Guid id)
    {
        var quizAnswer = await _quizAnswerRepository.GetQuizAnswersByIdAsync(id);
        
        if (quizAnswer == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        quizAnswer = await _quizAnswerRepository.DeleteAsync(quizAnswer);

        var quizAnswerDtoDto = _mapper.Map<QuizAnswerDto>(quizAnswer);
        
        return quizAnswerDtoDto;
    }

    public async Task<QuizAnswerDto> GetQuizAnswerByIdAsync(Guid id)
    {
        var quizAnswer = await _quizAnswerRepository.GetQuizAnswersByIdAsync(id);
        
        if (quizAnswer == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }

        var quizAnswerDtoDto = _mapper.Map<QuizAnswerDto>(quizAnswer);
        
        return quizAnswerDtoDto;
    }

    public async Task<IReadOnlyCollection<QuizAnswerDto>> GetAllQuizAnswersAsync()
    {
        var quizAnswer = await _quizAnswerRepository.GetAllQuizAnswersAsync();
        
        if (quizAnswer == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }

        var quizAnswerDtoDto = _mapper.Map<IReadOnlyCollection<QuizAnswerDto>>(quizAnswer);
        
        return quizAnswerDtoDto;
    }

    public async Task<IReadOnlyCollection<QuizAnswerDto>> GetAnswersByQuestionAnswersAsync(Guid id)
    {
        var quizAnswer = await _quizAnswerRepository.GetQuizAnswersByQuestionIdAsync(id);
        
        if (quizAnswer == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }

        var quizAnswerDto = _mapper.Map<IReadOnlyCollection<QuizAnswerDto>>(quizAnswer);
        
        return quizAnswerDto;
    }
}
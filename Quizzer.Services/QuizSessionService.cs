﻿using AutoMapper;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Entities;
using Quizzer.Services.Helpers;
using Quizzer.Services.Interfaces;

namespace Quizzer.Services;

public class QuizSessionService : IQuizSessionService
{
    private readonly IQuizSessionRepository _quizSessionRepository;
    private readonly IQuizRepository _quizRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    
    public QuizSessionService(IQuizSessionRepository quizSessionRepository, IQuizRepository quizRepository, 
        IMapper mapper, IUserRepository userRepository)
    {
        _quizSessionRepository = quizSessionRepository;
        _quizRepository = quizRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }
    
    public async Task<QuizSessionDto> CreateQuizSessionAsync(QuizSessionDto quizSessionDto)
    {
        var quizSessionEntity = _mapper.Map<QuizSession>(quizSessionDto);
        
        var quiz = await _quizRepository.GetQuizByIdAsync(quizSessionDto.QuizId);
        if (quiz.IsMultiplayer)
        {
            quizSessionEntity.QuizCode = CodeGenerator.GenerateUniqueQuizCode();
        }
        else
        {
            quizSessionEntity.QuizCode = null;
        }
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

    public async Task UpdateQuizSessionStartDate(Guid quizSessionId, DateTime startDate)
    {
        var quizSession = await _quizSessionRepository.GetByIdAsync(quizSessionId);
        if (quizSession != null)
        {
            quizSession.StartDate = startDate;
            await _quizSessionRepository.UpdateAsync(quizSession);
        }
        else
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
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
    
    public async Task<QuizSessionDto> GetQuizSessionByCodeAsync(int code)
    {
        var quizSession = await _quizSessionRepository.GetByCodeAsync(code);
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
    
    public async Task<IReadOnlyCollection<UserDto>> GetUsersInQuizSessionAsync(Guid quizSessionId)
    {
        var users = await _userRepository.GetUsersByQuizSession(quizSessionId);
        var userDtos = _mapper.Map<IReadOnlyCollection<UserDto>>(users);
        
        return userDtos;
    }
}
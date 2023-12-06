﻿using Microsoft.EntityFrameworkCore;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Entities;

namespace Quizzer.Data.Repositories;

public class QuizSessionRepository : Repository<QuizSession>, IQuizSessionRepository
{
    public QuizSessionRepository(QuizzerDbContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public async Task<QuizSession> GetByIdAsync(Guid id)
    {
        var session = await Data.AsNoTracking()
            .Include(s=>s.QuizSessionResults)
            .FirstOrDefaultAsync(s => s.Id == id);

        return session;
    }

    public async Task<IReadOnlyCollection<QuizSession>> GetQuizSessionByQuizIdAsync(Guid quizId)
    {
        var sessions = await Data.AsNoTracking().Where(s => s.QuizId == quizId).ToListAsync();

        return sessions;
    }

    public async Task<IReadOnlyCollection<QuizSession>> GetAllQuizSessionsAsync()
    {
        var quizSessions = await Data.AsNoTracking().ToListAsync();

        return quizSessions;
    }
}
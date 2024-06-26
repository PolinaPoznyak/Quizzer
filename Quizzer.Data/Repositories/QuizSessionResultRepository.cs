﻿using Microsoft.EntityFrameworkCore;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Entities;

namespace Quizzer.Data.Repositories;

public class QuizSessionResultRepository : Repository<QuizSessionResult>, IQuizSessionResultRepository
{
    public QuizSessionResultRepository(QuizzerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<QuizSessionResult> GetByIdAsync(Guid id)
    {
        var sessionResult = await Data.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);

        return sessionResult;
    }
    
    public async Task<QuizSessionResult> GetResultByIdWithDetailsAsync(Guid id)
    {
        var sessionResult = await Data.AsNoTracking()
            .Include(qsr => qsr.ResultDetails)
            .FirstOrDefaultAsync(s => s.Id == id);

        return sessionResult;
    }
    
    public async Task<IReadOnlyCollection<QuizSessionResult>> GetAllQuizSessionResultAsync()
    {
        var sessionResult = await Data.AsNoTracking().ToListAsync();

        return sessionResult;
    }
    
    public async Task<QuizSessionResult> GetByUserIdAndQuizSessionIdAsync(Guid userId, Guid quizSessionId)
    {
        var result = await Data.AsNoTracking()
            .FirstOrDefaultAsync(qsr => 
                qsr.UserId == userId && 
                qsr.QuizSessionId == quizSessionId);
        return result;
    }
}
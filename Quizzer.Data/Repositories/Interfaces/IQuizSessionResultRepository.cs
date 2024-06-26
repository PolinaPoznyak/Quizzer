﻿using Quizzer.Entities;

namespace Quizzer.Data.Repositories.Interfaces;

public interface IQuizSessionResultRepository : IRepository<QuizSessionResult>
{
    Task<QuizSessionResult> GetByIdAsync(Guid id);
    Task<QuizSessionResult> GetResultByIdWithDetailsAsync(Guid id);
    Task<IReadOnlyCollection<QuizSessionResult>> GetAllQuizSessionResultAsync();
    Task<QuizSessionResult> GetByUserIdAndQuizSessionIdAsync(Guid userId, Guid quizSessionId);
}
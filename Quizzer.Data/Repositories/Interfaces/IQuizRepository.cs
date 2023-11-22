using Quizzer.Entities;

namespace Quizzer.Data.Repositories.Interfaces;

public interface IQuizRepository : IRepository<Quiz>
{
    Task<Quiz> GetQuizByIdAsync(Guid id);
}
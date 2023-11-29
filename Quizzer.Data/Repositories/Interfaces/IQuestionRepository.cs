using Quizzer.Entities;

namespace Quizzer.Data.Repositories.Interfaces;

public interface IQuestionRepository : IRepository<Question>
{
    public Task<Question> GetByIdAsync(Guid id);
    Task<IEnumerable<Question>> GetQuestionsByQuizIdAsync(Guid quizId);
}
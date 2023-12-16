using Quizzer.Entities;

namespace Quizzer.Data.Repositories.Interfaces;

public interface IQuizAnswerRepository : IRepository<QuizAnswer>
{
    Task<IReadOnlyCollection<QuizAnswer>> GetAllQuizAnswersAsync();
    Task<QuizAnswer> GetQuizAnswersByIdAsync(Guid id);
    Task<IReadOnlyCollection<QuizAnswer>> GetQuizAnswersByQuestionIdAsync(Guid questionId);
}
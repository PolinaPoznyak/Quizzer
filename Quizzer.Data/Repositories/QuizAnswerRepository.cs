using Microsoft.EntityFrameworkCore;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Entities;

namespace Quizzer.Data.Repositories;

public class QuizAnswerRepository : Repository<QuizAnswer>, IQuizAnswerRepository
{
    public QuizAnswerRepository(QuizzerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyCollection<QuizAnswer>> GetAllQuizAnswersAsync()
    {
        var users = await Data
            .AsNoTracking()
            .ToListAsync();

        return users;
    }

    public async Task<QuizAnswer> GetQuizAnswersByIdAsync(Guid answerId)
    {
        var user = await Data.AsNoTracking().FirstOrDefaultAsync(qa => qa.Id == answerId);
        
        return user;
    }
    
    public async Task<IReadOnlyCollection<QuizAnswer>> GetQuizAnswersByQuestionIdAsync(Guid questionId)
    {
        var answers = await Data.AsNoTracking()
            .Where(qa => qa.QuestionId == questionId)
            .ToListAsync();

        return answers;
    }
}
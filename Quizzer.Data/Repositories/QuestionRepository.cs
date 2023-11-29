using Microsoft.EntityFrameworkCore;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Entities;

namespace Quizzer.Data.Repositories;

public class QuestionRepository : Repository<Question>, IQuestionRepository
{
    public QuestionRepository(QuizzerDbContext repositoryContext)
        :base(repositoryContext)
    {
    }

    public async Task<Question> GetByIdAsync(Guid id)
    {
        var question = await Data.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);

        return question;
    }
    
        
    public async Task<IEnumerable<Question>> GetQuestionsByQuizIdAsync(Guid quizId)
    {
        return await Data.Where(q => q.QuizId == quizId).ToListAsync();
    }
}
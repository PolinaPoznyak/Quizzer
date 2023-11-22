using Microsoft.EntityFrameworkCore;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Entities;

namespace Quizzer.Data.Repositories;

public class QuestionRepository : Repository<Question>, IQuestionRepository
{
    public QuestionRepository(DbContext repositoryContext)
        :base(repositoryContext)
    {
    }

    public async Task<Question> GetByIdAsync(Guid id)
    {
        var question = await Data.FirstOrDefaultAsync(q => q.Id == id);

        return question;
    }
}
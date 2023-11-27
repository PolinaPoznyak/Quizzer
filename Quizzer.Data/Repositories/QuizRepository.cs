using Microsoft.EntityFrameworkCore;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Entities;

namespace Quizzer.Data.Repositories;

public class QuizRepository : Repository<Quiz>, IQuizRepository
{
    public QuizRepository(QuizzerDbContext repositoryContext)
        :base(repositoryContext)
    {
    }

    public async Task<IReadOnlyCollection<Quiz>> GetAllQuizzesAsync()
    {
        var quizzes = await Data.OrderBy(q => q.Title)
            .AsNoTracking()
            .ToListAsync();

        return quizzes;
    }

    public async Task<Quiz> GetQuizByIdAsync(Guid id)
    {
        var quiz = await Data.FirstOrDefaultAsync(q => q.Id == id);

        return quiz;
    }
}
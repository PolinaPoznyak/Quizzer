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
        var quizzes = await Data.AsNoTracking().Include(q => q.Questions).OrderBy(q => q.Title)
            .ToListAsync();

        return quizzes;
    }

    public async Task<IReadOnlyCollection<Quiz>> GetQuizzesByUserIdAsync(Guid id)
    {
        var quizzes = await Data.AsNoTracking()
            .Include(q => q.Questions)
            .Where(q => q.UserId == id)
            .OrderBy(q => q.Title)
            .ToListAsync();

        return quizzes;
    }

    public async Task<IReadOnlyCollection<Quiz>> GetQuizzesByTitleAsync(string title)
    {
        var quizzes = await Data.AsNoTracking()
            .Include(q => q.Questions)
            .Where(q => q.Description == title)
            .OrderBy(q => q.Title)
            .ToListAsync();

        return quizzes;
    }

    public async Task<Quiz> GetQuizByIdAsync(Guid id)
    {
        var quiz = await Data.AsNoTracking()
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(q => q.Id == id);

        return quiz;
    }
}
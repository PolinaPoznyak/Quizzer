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

    public async Task<Quiz> GetQuizByIdAsync(Guid id)
    {
        var quiz = await Data.FirstOrDefaultAsync(q => q.Id == id);

        return quiz;
    }
}

/*public interface IQuizRepository : IRepository<Quiz> { }

public class QuizRepository : IQuizRepository
{
    private readonly AppDbContext _context;

    public QuizRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Quiz> Get() => _context.Quizzes;
    public Quiz Get(Guid id) => _context.Quizzes.Find(id);
    public void Create(Quiz item) => _context.Quizzes.Add(item);
    public void Update(Quiz item) => _context.Quizzes.Update(item);
    public Quiz Delete(Guid id)
    {
        Quiz quiz = Get(id);
        if (quiz != null)
            _context.Quizzes.Remove(quiz);
        return quiz;
    }
}*/
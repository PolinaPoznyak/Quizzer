using Microsoft.EntityFrameworkCore;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Entities;

namespace Quizzer.Data.Repositories;

public class QuizSessionRepository : Repository<QuizSession>, IQuizSessionRepository
{
    private readonly IUserRepository _userRepository;
    public QuizSessionRepository(QuizzerDbContext repositoryContext, IUserRepository userRepository) : base(repositoryContext)
    {
        _userRepository = userRepository;
    }
    
    public async Task<QuizSession> GetByIdAsync(Guid id)
    {
        var session = await Data.AsNoTracking()
            .Include(s=>s.QuizSessionResults)
            .FirstOrDefaultAsync(s => s.Id == id);

        return session;
    }    
    
    public async Task<QuizSession> GetByCodeAsync(int quizCode)
    {
        var session = await Data.AsNoTracking()
            .Include(s=>s.QuizSessionResults)
            .FirstOrDefaultAsync(s => s.QuizCode == quizCode);

        return session;
    }

    public async Task<IReadOnlyCollection<QuizSession>> GetQuizSessionByQuizIdAsync(Guid quizId)
    {
        var sessions = await Data.AsNoTracking().Where(s => s.QuizId == quizId).ToListAsync();

        return sessions;
    }

    public async Task<IReadOnlyCollection<QuizSession>> GetAllQuizSessionsAsync()
    {
        var quizSessions = await Data.AsNoTracking().ToListAsync();

        return quizSessions;
    }
}
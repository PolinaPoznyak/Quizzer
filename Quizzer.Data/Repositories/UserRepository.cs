using Microsoft.EntityFrameworkCore;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Entities;

namespace Quizzer.Data.Repositories;


public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(QuizzerDbContext dbContext)
        :base(dbContext)
    {
    }

    public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
    {
        var users = await Data.OrderBy(u => u.Username)
            .AsNoTracking()
            .ToListAsync();

        return users;
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        var user = await Data.AsNoTracking().SingleOrDefaultAsync(u => u.Id == userId);
        
        return user;
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        var user = await Data.AsNoTracking().SingleOrDefaultAsync(u => u.Username == username);

        return user;
    }

    public async Task<User> GetUserWithCreatedQuizzesAsync(Guid userId)
    {
        var user = await Data
            .Include(cq => cq.CreatedQuizzes)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return user;
    }
}
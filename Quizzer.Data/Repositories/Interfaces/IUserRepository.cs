using Quizzer.Entities;

namespace Quizzer.Data.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<IReadOnlyCollection<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid userId);
    Task<User> GetUserWithCreatedQuizzesAsync(Guid userId);
}
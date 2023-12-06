using Quizzer.Entities;

namespace Quizzer.Data.Repositories.Interfaces;

public interface IResultDetailsRepository : IRepository<ResultDetails>
{
    Task<ResultDetails> GetByIdAsync(Guid id);
    Task<IReadOnlyCollection<ResultDetails>> GetByQuizSessionResultIdAsync(Guid quizSessionResultId);
    Task<IReadOnlyCollection<ResultDetails>> GetAllResultDetailsAsync();
}
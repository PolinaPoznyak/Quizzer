using Microsoft.EntityFrameworkCore;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Entities;

namespace Quizzer.Data.Repositories;

public class ResultDetailsRepository : Repository<ResultDetails>, IResultDetailsRepository
{
    public ResultDetailsRepository(QuizzerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ResultDetails> GetByIdAsync(Guid id)
    {
        var resultDetail = await Data.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);

        return resultDetail;
    }

    public async Task<IReadOnlyCollection<ResultDetails>> GetByQuizSessionResultIdAsync(Guid quizSessionResultId)
    { 
        var resultDetails = await Data
            .AsNoTracking()
            .Include(rd => rd.Question)
            .ThenInclude(q => q.Answers)
            .Include(rd => rd.QuizAnswer)
            .Where(rd => rd.QuizSessionResultId == quizSessionResultId)
            .ToListAsync(); 

        return resultDetails;
    }
    
    public async Task<IReadOnlyCollection<ResultDetails>> GetAllResultDetailsAsync()
    {
        var resultDetails = await Data.AsNoTracking().ToListAsync();

        return resultDetails;
    }
}
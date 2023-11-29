using Microsoft.EntityFrameworkCore;
using Quizzer.Data.Repositories.Interfaces;

namespace Quizzer.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _dbContext;
    
    protected readonly DbSet<T> Data;
    
    public Repository(QuizzerDbContext dbContext)
    {
        _dbContext = dbContext;
        Data = _dbContext.Set<T>();
    }
    
    
    public async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        var result = await Data.AsNoTracking().ToListAsync();

        return result;
    }

    public async Task<T> CreateAsync(T item)
    {
        Data.Add(item);
        await _dbContext.SaveChangesAsync();

        return item;
    }

    public async Task<T> UpdateAsync(T item)
    {
        Data.Attach(item);
        Data.Update(item);
        await _dbContext.SaveChangesAsync();
        
        return item;
    }

    public async Task<T> DeleteAsync(T item)
    {
        Data.Remove(item);
        await _dbContext.SaveChangesAsync();

        return item;
    }

    protected async Task<int> SaveChangesAsync()
    {
        var result = await _dbContext.SaveChangesAsync();

        return result;
    }
    
    public void Detach(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Detached;
    }
}
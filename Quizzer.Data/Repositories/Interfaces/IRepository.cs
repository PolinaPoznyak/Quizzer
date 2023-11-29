namespace Quizzer.Data.Repositories.Interfaces;

public interface IRepository<T>
{
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<T> CreateAsync(T item);
    Task<T> UpdateAsync(T item);
    Task<T> DeleteAsync(T item);
    void Detach(T entity);
}
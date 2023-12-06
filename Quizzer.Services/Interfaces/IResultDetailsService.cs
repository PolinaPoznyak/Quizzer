using Quizzer.Dtos;

namespace Quizzer.Services.Interfaces;

public interface IResultDetailsService
{
    Task<ResultDetailsDto> CreateResultDetailAsync(ResultDetailsDto resultDetailDto);
    Task<ResultDetailsDto> UpdateResultDetailAsync(ResultDetailsDto resultDetailDto);
    Task<ResultDetailsDto> DeleteResultDetailAsync(Guid id);
    Task<ResultDetailsDto> GetResultDetailByIdAsync(Guid id);
    Task<IReadOnlyCollection<ResultDetailsDto>> GetAllResultDetailsAsync();
}
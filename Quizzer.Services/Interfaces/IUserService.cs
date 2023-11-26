using Quizzer.Dtos;

namespace Quizzer.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateUserAnsync(UserDto userDto);
    Task<UserDto> UpdateUserAsync(UserDto userDto);
    Task<UserDto> DeleteUserAsync(Guid id);
    Task<IReadOnlyCollection<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(Guid id);
}
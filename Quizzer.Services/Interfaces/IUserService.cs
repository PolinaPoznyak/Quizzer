using Quizzer.Dtos;

namespace Quizzer.Services.Interfaces;

public interface IUserService
{
    string GenerateJwtToken(UserDto userDto);
    Task<UserDto> AuthenticateAsync(string username, string password);
    Task<UserDto> CreateUserAsync(UserDto userDto, string role);
    Task<UserDto> UpdateUserAsync(UserDto userDto);
    Task<UserDto> PatchUserAsync(UserDto userDto);
    Task<UserDto> DeleteUserAsync(Guid id);
    Task<IReadOnlyCollection<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(Guid id);
    Task<UserDto> GetUserByUsernameAsync(string username);
}
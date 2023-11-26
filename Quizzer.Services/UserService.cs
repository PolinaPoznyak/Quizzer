using AutoMapper;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Entities;
using Quizzer.Services.Interfaces;

namespace Quizzer.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateUserAnsync(UserDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);
        await _userRepository.CreateAsync(userEntity);
        userDto = _mapper.Map<UserDto>(userEntity);

        return userDto;
    }

    public async Task<UserDto> UpdateUserAsync(UserDto userDto)
    {
        var existingUser = await _userRepository.GetUserByIdAsync(userDto.Id);

        if (existingUser == null)
        {
            return null;
        }

        existingUser.Username = userDto.Username;
        existingUser.FullName = userDto.FullName;
        existingUser.ProfilePicture = userDto.ProfilePicture;
        
        await _userRepository.UpdateAsync(existingUser);

        return userDto;
    }

    public async Task<UserDto> DeleteUserAsync(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        
        if (user == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        user = await _userRepository.DeleteAsync(user);

        var userDto = _mapper.Map<UserDto>(user);
        
        return userDto;
    }

    public async Task<IReadOnlyCollection<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        
        if (users == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        var userDtos = _mapper.Map<IReadOnlyCollection<UserDto>>(users);

        return userDtos;
    }
    
    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        
        if (user == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }
}
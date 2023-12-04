using AutoMapper;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Entities;
using Quizzer.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Quizzer.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    private readonly IConfiguration _configuration;
    
    public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _configuration = configuration;
    }
    
    public string GenerateJwtToken(UserDto userDto)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, userDto.Username),
            new Claim(JwtRegisteredClaimNames.UniqueName, userDto.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, userDto.Email),
            new Claim(ClaimTypes.Role, userDto.Role),
           
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value!));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            "http://localhost:5045",
            "http://localhost:5045",
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public async Task<UserDto> AuthenticateAsync(string username, string password)
    {
        var userEntity = await _userRepository.GetUserByUsernameAsync(username);

        if (userEntity == null || !BCrypt.Net.BCrypt.Verify(password, userEntity.Password))
        {
            return null;
            // TODO: Throw Exception (custom)
        }

        var userDto = _mapper.Map<UserDto>(userEntity);

        return userDto;
    }

    public async Task<UserDto> CreateUserAsync(UserDto userDto, string role = "User")
    {
        userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        userDto.Role = role;
        userDto.IsDeleted = false;
        
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

    public async Task<UserDto> GetUserByUsernameAsync(string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        
        if (user == null)
        {
            // TODO: Throw ItemNotFoundException (custom)
        }
        
        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }
}
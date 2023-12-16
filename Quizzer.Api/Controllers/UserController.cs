using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizzer.Api.Models.Request.Users;
using Quizzer.Api.Models.Response.Users;
using Quizzer.Data.Repositories.Interfaces;
using Quizzer.Dtos;
using Quizzer.Services.Interfaces;

namespace Quizzer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        private readonly IMapper _mapper;

        
        public UserController(IUserService repository, IMapper mapper)
        {
            _userService = repository;
            _mapper = mapper;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateRequestModel userRequest)
        {
            var userDto = _mapper.Map<UserDto>(userRequest);
            var createdUser = await _userService.CreateUserAsync(userDto, role: "User");

            var token = _userService.GenerateJwtToken(createdUser);

            return Ok(new { Token = token });
        }

        [HttpPost("register/admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin(UserCreateRequestModel userRequest)
        {
            var userDto = _mapper.Map<UserDto>(userRequest);
            var createdAdmin = await _userService.CreateUserAsync(userDto, role: "Admin");

            var token = _userService.GenerateJwtToken(createdAdmin);

            return Ok(new { Token = token });
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserCreateRequestModel userRequest)
        {
            var userDto = await _userService.AuthenticateAsync(userRequest.Username, userRequest.Password);

            if (userDto == null)
            {
                return Unauthorized();
            }
            var token = _userService.GenerateJwtToken(userDto);

            return Ok(new { Token = token });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateRequestModel userRequest)
        {
            var existingUser = await _userService.GetUserByIdAsync(userRequest.Id);

            if (existingUser == null)
            {
                return NotFound($"User with Id {userRequest.Id} not found.");
            }
            var updatedUserDto = _mapper.Map<UserDto>(userRequest);
            updatedUserDto.Password = existingUser.Password;
            var updatedUser = await _userService.UpdateUserAsync(updatedUserDto);
            var userResponse = _mapper.Map<UserUpdateResponseModel>(updatedUser);

            return Ok(userResponse);
        } 
        
        [HttpPatch("block")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BlockUser(UserPatchRequestModel userRequest)
        {
            var existingUser = await _userService.GetUserByIdAsync(userRequest.Id);

            if (existingUser == null)
            {
                return NotFound($"User with Id {userRequest.Id} not found.");
            }
            var updatedUserDto = _mapper.Map<UserDto>(userRequest);
            updatedUserDto.Password = existingUser.Password;
            var updatedUser = await _userService.PatchUserAsync(updatedUserDto);
            var userResponse = _mapper.Map<UserPatchResponseModel>(updatedUser);

            return Ok(userResponse);
        }
        
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var userDto = await _userService.DeleteUserAsync(id);
            var userResponse = _mapper.Map<UserDeleteResponseModel>(userDto);

            return Ok(userResponse);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            var userResponse = _mapper.Map<UserGetResponseModel>(userDto);

            return Ok(userResponse);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var userDtos = await _userService.GetAllUsersAsync();

            var userResponse = userDtos.Select(userDto => _mapper.Map<UserGetResponseModel>(userDto));

            return Ok(userResponse);
        }
    }
}

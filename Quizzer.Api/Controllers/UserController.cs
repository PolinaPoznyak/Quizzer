using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizzer.Data.Repositories.Interfaces;

namespace Quizzer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        
        private readonly IMapper _mapper;

        
        public UserController(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }
    }
}

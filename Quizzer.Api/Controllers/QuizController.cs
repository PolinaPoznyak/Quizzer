using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quizzer.Data.Repositories.Interfaces;

namespace Quizzer.Api.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;
        
        private readonly IMapper _mapper;
        
        
        public QuizController(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }
    }
using System.Net.WebSockets;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizzer.Api.Models.Request.QuizSessionResult;
using Quizzer.Api.Models.Response.QuizSessionResult;
using Quizzer.Dtos;
using Quizzer.Services.Interfaces;

namespace Quizzer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizSessionResultController : ControllerBase
{
    private readonly IQuizSessionResultService _quizSessionResultService;
    private readonly IMapper _mapper;
        
        
    public QuizSessionResultController(IQuizSessionResultService quizSessionResultService, IMapper mapper)
    {
        _quizSessionResultService = quizSessionResultService;
        _mapper = mapper;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateQuizSession(QuizSessionResultCreateRequestModel quizSessionResultRequest)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.Name);

        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
        {
            return BadRequest("Invalid user ID");
        }
        var quizSessionResultDto = _mapper.Map<QuizSessionResultDto>(quizSessionResultRequest);

        quizSessionResultDto.UserId = userId;
        
        var quizSessionResult = await _quizSessionResultService.CreateQuizSessionResultAsync(quizSessionResultDto);
        var quizSessionResultResponse = _mapper.Map<QuizSessionResultCreateResponseModel>(quizSessionResult);
    
        return Ok(quizSessionResultResponse);
    }
    
    [Authorize]
    [HttpPost("multiplayer-quiz")]
    public async Task<IActionResult> CreateQuizSessionResultByQuizCode(int quizCode)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.Name);

        if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
        {
            return BadRequest("Invalid user ID");
        }
        var quizSessionResult = await _quizSessionResultService.CreateQuizSessionResultByCodeAsync(quizCode, userId);
        var quizSessionResultResponse = _mapper.Map<QuizSessionResultCreateResponseModel>(quizSessionResult);
    
        return Ok(quizSessionResultResponse);
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateResultDetail(QuizSessionResultUpdateRequestModel resultDetailsRequest)
    {
        var quizSessionResultDto = _mapper.Map<QuizSessionResultDto>(resultDetailsRequest);
        var quizSessionResult = await _quizSessionResultService.UpdateQuizSessionResultAsync(quizSessionResultDto);
        var quizSessionResultResponse = _mapper.Map<QuizSessionResultUpdateResponseModel>(quizSessionResult);
    
        return Ok(quizSessionResultResponse);
    }
     
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteQuizSessionResult(Guid id)
    {
        var quizSessionResultDto = await _quizSessionResultService.DeleteQuizSessionResultAsync(id);
        var quizSessionResultResponse = _mapper.Map<QuizSessionResultDeleteResponseModel>(quizSessionResultDto);

        return Ok(quizSessionResultResponse);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetQuizSessionResultById(Guid id)
    {
        var quizSessionResultDto = await _quizSessionResultService.GetQuizSessionResultByIdAsync(id);
        var quizSessionResultResponse = _mapper.Map<QuizSessionResultGetResponseModel>(quizSessionResultDto);
    
        return Ok(quizSessionResultResponse);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetQuizSessionResults()
    {
        var quizSessionResultDtos = await _quizSessionResultService.GetAllQuizSessionResultsAsync();
        var quizSessionResultResponse = quizSessionResultDtos.Select(quizSessionResultDto => _mapper.Map<QuizSessionResultGetResponseModel>(quizSessionResultDto));
    
        return Ok(quizSessionResultResponse);
    }

//     [Route("/ws")]
//     public async Task GetQuizStartDate()
//     {
//         if (HttpContext.WebSockets.IsWebSocketRequest)
//         {
//             using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
//             await Echo(webSocket);
//         }
//         else
//         {
//             HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
//         }
//     }
//     
//     private static async Task Echo(WebSocket webSocket)
//     {
//         var buffer = new byte[1024 * 4];
//         var receiveResult = await webSocket.ReceiveAsync(
//             new ArraySegment<byte>(buffer), CancellationToken.None);
//
//         while (!receiveResult.CloseStatus.HasValue)
//         {
//             
//             
//             await webSocket.SendAsync(
//                 new ArraySegment<byte>(buffer, 0, receiveResult.Count),
//                 receiveResult.MessageType,
//                 receiveResult.EndOfMessage,
//                 CancellationToken.None);
//
//             receiveResult = await webSocket.ReceiveAsync(
//                 new ArraySegment<byte>(buffer), CancellationToken.None);
//         }
//
//         await webSocket.CloseAsync(
//             receiveResult.CloseStatus.Value,
//             receiveResult.CloseStatusDescription,
//             CancellationToken.None);
//     }
 }
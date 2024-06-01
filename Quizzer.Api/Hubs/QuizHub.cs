using Microsoft.AspNetCore.SignalR;
using Quizzer.Services.Interfaces;

namespace Quizzer.Api.Hubs;

public class QuizHub : Hub
{
    private readonly IQuizSessionResultService _quizSessionResultService;
    private readonly IQuizSessionService _quizSessionService;
    
    public QuizHub(IQuizSessionResultService quizSessionResultService, IQuizSessionService quizSessionService)
    {
        _quizSessionResultService = quizSessionResultService;
        _quizSessionService = quizSessionService;
    }
    
    // move to class as in ts interface
    public async Task ConnectToQuizSession(int quizCode, Guid userId)
    {
        if (Guid.Empty != userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, quizCode.ToString());
            var result = await _quizSessionResultService.CreateQuizSessionResultByCodeAsync(quizCode, userId);
            var quizUsers = await _quizSessionService.GetUsersInQuizSessionAsync(result.QuizSessionId);
            await Clients.Group(quizCode.ToString())
                .SendAsync("Notify", quizUsers);
        }
    }
    
    public async Task StartQuizSession(Guid quizSessionId)
    {
        await _quizSessionService.UpdateQuizSessionStartDate(quizSessionId, DateTime.UtcNow);
    
        await Clients.All.SendAsync("QuizStarted");
    }
}
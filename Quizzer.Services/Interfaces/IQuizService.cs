using Quizzer.Dtos;

namespace Quizzer.Services.Interfaces;

public interface IQuizService
{
    Task<QuizDto> CreateQuizAsync(QuizDto quizDto);
    Task<QuizDto> UpdateQuizAsync(QuizDto quizDto);
    Task<QuizDto> DeleteQuizAsync(Guid id);
    Task<IReadOnlyCollection<QuizDto>> GetAllQuizzesAsync();
    Task<QuizDto> GetQuizByIdAsync(Guid id);
}
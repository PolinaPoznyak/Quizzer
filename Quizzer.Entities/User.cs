namespace Quizzer.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public string? FullName { get; set; }
    
    public string? ProfilePicture { get; set; }
    
    public string Role { get; set; }
    
    public bool IsDeleted { get; set; }

    public ICollection<Quiz> CreatedQuizzes { get; set; }
    
    public ICollection<QuizSessionResult>? QuizSessionResults { get; set; }
}
namespace Quizzer.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }

    public string Email { get; set; }
    
    public string? FullName { get; set; }
    
    public string? ProfilePicture { get; set; }
    
    public string? Role { get; set; }
    
    public IEnumerable<QuizDto>? CreatedQuizzes { get; set; }
    
    //public IEnumerable<ActiveQuizDto>? ActiveQuizzes { get; set; }
}
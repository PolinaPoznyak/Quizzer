using Microsoft.EntityFrameworkCore;
using Quizzer.Entities;

namespace Quizzer.Data;

public class QuizzerDbContext : DbContext
{

    public QuizzerDbContext(DbContextOptions<QuizzerDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuizAnswer> QuizAnswers { get; set; }
    public DbSet<ActiveQuiz> ActiveQuizzes { get; set; }
    public DbSet<UserResult> UserResults { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
}
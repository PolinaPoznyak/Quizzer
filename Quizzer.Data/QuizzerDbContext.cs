using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ActiveQuizConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        modelBuilder.ApplyConfiguration(new QuizConfiguration());
        modelBuilder.ApplyConfiguration(new QuizAnswerConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserAnswerConfiguration());
        modelBuilder.ApplyConfiguration(new UserResultConfiguration());
    }
}

    public class ActiveQuizConfiguration : IEntityTypeConfiguration<ActiveQuiz>
    {
        public void Configure(EntityTypeBuilder<ActiveQuiz> builder)
        {
            builder.HasKey(aq => aq.Id);

            builder.HasOne(aq => aq.User)
                .WithMany(u => u.ActiveQuizzes)
                .HasForeignKey(aq => aq.UserId);

            builder.HasOne(aq => aq.Quiz)
                .WithMany(q => q.ActiveQuizzes)
                .HasForeignKey(aq => aq.QuizId);

            builder.HasOne(aq => aq.Result)
                .WithOne(ur => ur.ActiveQuiz)
                .HasForeignKey<UserResult>(ur => ur.ActiveQuizId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }

    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);

            builder.HasOne(q => q.Quiz)
                .WithMany(qz => qz.Questions)
                .HasForeignKey(q => q.QuizId);

            builder.HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);
        }
    }

    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(q => q.Id);

            builder.HasOne(q => q.User)
                .WithMany(u => u.CreatedQuizzes)
                .HasForeignKey(q => q.UserId);

            builder.HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId);

            builder.HasMany(q => q.ActiveQuizzes)
                .WithOne(aq => aq.Quiz)
                .HasForeignKey(aq => aq.QuizId);
        }
    }

    public class QuizAnswerConfiguration : IEntityTypeConfiguration<QuizAnswer>
    {
        public void Configure(EntityTypeBuilder<QuizAnswer> builder)
        {
            builder.HasKey(qa => qa.Id);

            builder.HasOne(qa => qa.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(qa => qa.QuestionId);
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Username)
                .IsUnique(); 

            builder.HasMany(u => u.CreatedQuizzes)
                .WithOne(q => q.User)
                .HasForeignKey(q => q.UserId);

            builder.HasMany(u => u.ActiveQuizzes)
                .WithOne(aq => aq.User)
                .HasForeignKey(aq => aq.UserId);
        }
    }

    public class UserAnswerConfiguration : IEntityTypeConfiguration<UserAnswer>
    {
        public void Configure(EntityTypeBuilder<UserAnswer> builder)
        {
            builder.HasKey(ua => ua.Id);

            builder.HasOne(ua => ua.UserResult)
                .WithOne(ur => ur.UserAnswer)
                .HasForeignKey<UserResult>(ur => ur.UserAnswerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }

    public class UserResultConfiguration : IEntityTypeConfiguration<UserResult>
    {
        public void Configure(EntityTypeBuilder<UserResult> builder)
        {
            builder.HasKey(ur => ur.Id);

            builder.HasOne(ur => ur.ActiveQuiz)
                .WithOne(aq => aq.Result)
                .HasForeignKey<UserResult>(ur => ur.ActiveQuizId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ur => ur.UserAnswer)
                .WithOne(ua => ua.UserResult)
                .HasForeignKey<UserResult>(ur => ur.UserAnswerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
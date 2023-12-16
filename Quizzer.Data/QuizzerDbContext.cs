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
    public DbSet<QuizSession> QuizSessions { get; set; }
    public DbSet<QuizSessionResult> QuizSessionResults { get; set; }
    public DbSet<ResultDetails> ResultDetails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new QuizSessionConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        modelBuilder.ApplyConfiguration(new QuizConfiguration());
        modelBuilder.ApplyConfiguration(new QuizAnswerConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ResultDetailConfiguration());
        modelBuilder.ApplyConfiguration(new QuizSessionResultConfiguration());
    }
}

    public class QuizSessionConfiguration : IEntityTypeConfiguration<QuizSession>
    {
        public void Configure(EntityTypeBuilder<QuizSession> builder)
        {
            builder.HasKey(qs => qs.Id);

            builder.HasOne(qs => qs.Quiz)
                .WithMany(q => q.QuizSessions)
                .HasForeignKey(qs => qs.QuizId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(qs => qs.QuizSessionResults)
                .WithOne(qsr => qsr.QuizSession)
                .HasForeignKey(qsr => qsr.QuizSessionId)
                .OnDelete((DeleteBehavior.Restrict));
            //TODO: change delete cascade
        }
    }

    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);

            builder.HasOne(q => q.Quiz)
                .WithMany(qz => qz.Questions)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.Answers)
                .WithOne(qa => qa.Question)
                .HasForeignKey(qa => qa.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(q => q.ResultDetails)
                .WithOne(rd => rd.Question)
                .HasForeignKey(rd => rd.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(q => q.Id);

            builder.HasOne(qz => qz.User)
                .WithMany(u => u.CreatedQuizzes)
                .HasForeignKey(qz => qz.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(qz => qz.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(qz => qz.QuizSessions)
                .WithOne(qs => qs.Quiz)
                .HasForeignKey(qs => qs.QuizId)
                .OnDelete(DeleteBehavior.Restrict);
            //TODO: change to Cascade
        }
    }

    public class QuizAnswerConfiguration : IEntityTypeConfiguration<QuizAnswer>
    {
        public void Configure(EntityTypeBuilder<QuizAnswer> builder)
        {
            builder.HasKey(qa => qa.Id);

            builder.HasOne(qa => qa.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(qa => qa.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(qa => qa.ResultDetails)
                .WithOne(rd => rd.QuizAnswer)
                .HasForeignKey(rd => rd.QuizAnswerId)
                .OnDelete(DeleteBehavior.Cascade);
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
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.QuizSessionResults)
                .WithOne(qsr => qsr.User)
                .HasForeignKey(qsr => qsr.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class ResultDetailConfiguration : IEntityTypeConfiguration<ResultDetails>
    {
        public void Configure(EntityTypeBuilder<ResultDetails> builder)
        {
            builder.HasKey(rd => rd.Id);
            
            builder.HasOne(rd => rd.QuizSessionResult)
                .WithMany(qsr => qsr.ResultDetails)
                .HasForeignKey(qd => qd.QuizSessionResultId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class QuizSessionResultConfiguration : IEntityTypeConfiguration<QuizSessionResult>
    {
        public void Configure(EntityTypeBuilder<QuizSessionResult> builder)
        {
            builder.HasKey(qsr => qsr.Id);
            
            builder.HasMany(qsr => qsr.ResultDetails)
                .WithOne(rd => rd.QuizSessionResult)
                .HasForeignKey(rd => rd.QuizSessionResultId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(qsr => qsr.QuizSession)
                .WithMany(qs => qs.QuizSessionResults)
                .HasForeignKey(qsr => qsr.QuizSessionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(qsr => qsr.User)
                .WithMany(u => u.QuizSessionResults)
                .HasForeignKey(qsr => qsr.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
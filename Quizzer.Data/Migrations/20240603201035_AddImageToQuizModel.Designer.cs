﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Quizzer.Data;

#nullable disable

namespace Quizzer.Data.Migrations
{
    [DbContext(typeof(QuizzerDbContext))]
    [Migration("20240603201035_AddImageToQuizModel")]
    partial class AddImageToQuizModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Quizzer.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("QuestionType")
                        .HasColumnType("text");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Quizzer.Entities.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsMultiplayer")
                        .HasColumnType("boolean");

                    b.Property<string>("QuizPicture")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("Quizzer.Entities.QuizAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuizAnswers");
                });

            modelBuilder.Entity("Quizzer.Entities.QuizSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("QuizCode")
                        .HasColumnType("integer");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("QuizSessions");
                });

            modelBuilder.Entity("Quizzer.Entities.QuizSessionResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuizSessionId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Score")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QuizSessionId");

                    b.HasIndex("UserId");

                    b.ToTable("QuizSessionResults");
                });

            modelBuilder.Entity("Quizzer.Entities.ResultDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("IsCorrect")
                        .HasColumnType("integer");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuizAnswerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuizSessionResultId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuizAnswerId");

                    b.HasIndex("QuizSessionResultId");

                    b.ToTable("ResultDetails");
                });

            modelBuilder.Entity("Quizzer.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Quizzer.Entities.Question", b =>
                {
                    b.HasOne("Quizzer.Entities.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Quizzer.Entities.Quiz", b =>
                {
                    b.HasOne("Quizzer.Entities.User", "User")
                        .WithMany("CreatedQuizzes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Quizzer.Entities.QuizAnswer", b =>
                {
                    b.HasOne("Quizzer.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Quizzer.Entities.QuizSession", b =>
                {
                    b.HasOne("Quizzer.Entities.Quiz", "Quiz")
                        .WithMany("QuizSessions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("Quizzer.Entities.QuizSessionResult", b =>
                {
                    b.HasOne("Quizzer.Entities.QuizSession", "QuizSession")
                        .WithMany("QuizSessionResults")
                        .HasForeignKey("QuizSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quizzer.Entities.User", "User")
                        .WithMany("QuizSessionResults")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuizSession");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Quizzer.Entities.ResultDetails", b =>
                {
                    b.HasOne("Quizzer.Entities.Question", "Question")
                        .WithMany("ResultDetails")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quizzer.Entities.QuizAnswer", "QuizAnswer")
                        .WithMany("ResultDetails")
                        .HasForeignKey("QuizAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quizzer.Entities.QuizSessionResult", "QuizSessionResult")
                        .WithMany("ResultDetails")
                        .HasForeignKey("QuizSessionResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("QuizAnswer");

                    b.Navigation("QuizSessionResult");
                });

            modelBuilder.Entity("Quizzer.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("ResultDetails");
                });

            modelBuilder.Entity("Quizzer.Entities.Quiz", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("QuizSessions");
                });

            modelBuilder.Entity("Quizzer.Entities.QuizAnswer", b =>
                {
                    b.Navigation("ResultDetails");
                });

            modelBuilder.Entity("Quizzer.Entities.QuizSession", b =>
                {
                    b.Navigation("QuizSessionResults");
                });

            modelBuilder.Entity("Quizzer.Entities.QuizSessionResult", b =>
                {
                    b.Navigation("ResultDetails");
                });

            modelBuilder.Entity("Quizzer.Entities.User", b =>
                {
                    b.Navigation("CreatedQuizzes");

                    b.Navigation("QuizSessionResults");
                });
#pragma warning restore 612, 618
        }
    }
}

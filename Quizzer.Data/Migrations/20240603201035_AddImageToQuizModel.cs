using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizzer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToQuizModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuizPicture",
                table: "Quizzes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizPicture",
                table: "Quizzes");
        }
    }
}

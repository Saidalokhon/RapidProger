using API.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public static class DatabaseSeeder
    {
        public static void Seed(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Title", "Content", "Type" },
                values: new object[,]
                {
                    { 1, "SomeTitle", "SomeContent", (int)QuestionType.Checkbox }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "SomeAnswer", true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Title", "Content", "Type" },
                values: new object[,]
                {
                    { 2, "SomeTitle1", "SomeContent1", (int)QuestionType.Checkbox }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 2, "SomeAnswer1", true, 1 }
                });
        }
    }
}

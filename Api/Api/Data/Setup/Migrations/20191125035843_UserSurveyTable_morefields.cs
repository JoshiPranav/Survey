using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class UserSurveyTable_morefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "UserSurveys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "UserSurveys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "UserSurveys",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "UserSurveys");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "UserSurveys");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "UserSurveys");
        }
    }
}

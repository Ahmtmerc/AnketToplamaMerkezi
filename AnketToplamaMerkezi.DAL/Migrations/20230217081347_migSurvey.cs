using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnketToplamaMerkezi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class migSurvey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "SavedSurveys",
                newName: "SurveyInformationId");

            migrationBuilder.AddColumn<int>(
                name: "SurveyAnswersId",
                table: "SavedSurveys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyAnswersId",
                table: "SavedSurveys");

            migrationBuilder.RenameColumn(
                name: "SurveyInformationId",
                table: "SavedSurveys",
                newName: "SurveyId");
        }
    }
}

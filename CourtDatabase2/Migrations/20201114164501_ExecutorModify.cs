using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtDatabase2.Migrations
{
    public partial class ExecutorModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CHSIExecutor",
                table: "Executors");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Executors",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Executors",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Executors",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Executors",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Executors");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Executors");

            migrationBuilder.AddColumn<int>(
                name: "CHSIExecutor",
                table: "Executors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

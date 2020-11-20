using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtDatabase2.Migrations
{
    public partial class CaseActionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "LegalActions");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CaseActions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "CaseActions");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "LegalActions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

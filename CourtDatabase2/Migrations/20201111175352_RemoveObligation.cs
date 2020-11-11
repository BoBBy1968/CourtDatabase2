using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtDatabase2.Migrations
{
    public partial class RemoveObligation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LawCases_Obligations_ObligationId",
                table: "LawCases");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Obligations_ObligationId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "LegalActionViewModel");

            migrationBuilder.DropTable(
                name: "Obligations");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ObligationId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_LawCases_ObligationId",
                table: "LawCases");

            migrationBuilder.DropColumn(
                name: "ObligationId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ObligationId",
                table: "LawCases");

            migrationBuilder.AddColumn<int>(
                name: "LawCaseId",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceCount",
                table: "LawCases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodFrom",
                table: "LawCases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodTo",
                table: "LawCases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "LawCases",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_LawCaseId",
                table: "Payments",
                column: "LawCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_LawCases_LawCaseId",
                table: "Payments",
                column: "LawCaseId",
                principalTable: "LawCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_LawCases_LawCaseId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_LawCaseId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "LawCaseId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "InvoiceCount",
                table: "LawCases");

            migrationBuilder.DropColumn(
                name: "PeriodFrom",
                table: "LawCases");

            migrationBuilder.DropColumn(
                name: "PeriodTo",
                table: "LawCases");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "LawCases");

            migrationBuilder.AddColumn<int>(
                name: "ObligationId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ObligationId",
                table: "LawCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LegalActionViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalActionViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obligations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceCount = table.Column<int>(type: "int", nullable: false),
                    LawCaseId = table.Column<int>(type: "int", nullable: true),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obligations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ObligationId",
                table: "Payments",
                column: "ObligationId");

            migrationBuilder.CreateIndex(
                name: "IX_LawCases_ObligationId",
                table: "LawCases",
                column: "ObligationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LawCases_Obligations_ObligationId",
                table: "LawCases",
                column: "ObligationId",
                principalTable: "Obligations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Obligations_ObligationId",
                table: "Payments",
                column: "ObligationId",
                principalTable: "Obligations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

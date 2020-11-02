using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtDatabase2.Data.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommonInterestRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonInterestRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourtTowns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TownName = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtTowns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Executors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHSIExecutor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeatEstates",
                columns: table => new
                {
                    AbNumber = table.Column<string>(maxLength: 11, nullable: false),
                    Address = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatEstates", x => x.AbNumber);
                });

            migrationBuilder.CreateTable(
                name: "LegalActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ActionName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obligations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(nullable: false),
                    PeriodFrom = table.Column<DateTime>(nullable: false),
                    PeriodTo = table.Column<DateTime>(nullable: false),
                    InvoiceCount = table.Column<int>(nullable: false),
                    LawCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obligations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtType = table.Column<int>(nullable: false),
                    CourtTownId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courts_CourtTowns_CourtTownId",
                        column: x => x.CourtTownId,
                        principalTable: "CourtTowns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 250, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    EGN = table.Column<string>(maxLength: 10, nullable: false),
                    AbNumber = table.Column<string>(maxLength: 11, nullable: true),
                    AddressToContact = table.Column<string>(maxLength: 150, nullable: true),
                    Phone = table.Column<string>(maxLength: 13, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Representative = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debitors_HeatEstates_AbNumber",
                        column: x => x.AbNumber,
                        principalTable: "HeatEstates",
                        principalColumn: "AbNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PaymentSource = table.Column<int>(nullable: false),
                    ObligationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Obligations_ObligationId",
                        column: x => x.ObligationId,
                        principalTable: "Obligations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(maxLength: 10, nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    Maturity = table.Column<DateTime>(nullable: false),
                    PeriodSince = table.Column<DateTime>(nullable: false),
                    PeriodTo = table.Column<DateTime>(nullable: false),
                    AbNumber = table.Column<string>(nullable: true),
                    DebitorId = table.Column<int>(nullable: false),
                    Condition = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_HeatEstates_AbNumber",
                        column: x => x.AbNumber,
                        principalTable: "HeatEstates",
                        principalColumn: "AbNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Debitors_DebitorId",
                        column: x => x.DebitorId,
                        principalTable: "Debitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LawCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    DebitorId = table.Column<int>(nullable: false),
                    ObligationId = table.Column<int>(nullable: false),
                    AbNumber = table.Column<string>(nullable: true),
                    MoratoriumInterest = table.Column<decimal>(nullable: true),
                    LegalInterest = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawCases_HeatEstates_AbNumber",
                        column: x => x.AbNumber,
                        principalTable: "HeatEstates",
                        principalColumn: "AbNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawCases_Debitors_DebitorId",
                        column: x => x.DebitorId,
                        principalTable: "Debitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LawCases_Obligations_ObligationId",
                        column: x => x.ObligationId,
                        principalTable: "Obligations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalActionId = table.Column<int>(nullable: false),
                    LawCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseActions_LawCases_LawCaseId",
                        column: x => x.LawCaseId,
                        principalTable: "LawCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseActions_LegalActions_LegalActionId",
                        column: x => x.LegalActionId,
                        principalTable: "LegalActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourtCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtId = table.Column<int>(nullable: false),
                    LawCaseId = table.Column<int>(nullable: false),
                    CaseNumber = table.Column<int>(nullable: false),
                    CaseYear = table.Column<DateTime>(nullable: false),
                    CourtChamber = table.Column<string>(nullable: true),
                    CaseType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourtCases_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourtCases_LawCases_LawCaseId",
                        column: x => x.LawCaseId,
                        principalTable: "LawCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExecutorCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutorId = table.Column<int>(nullable: false),
                    LawCaseId = table.Column<int>(nullable: false),
                    ExecutorCaseNumber = table.Column<int>(nullable: false),
                    Year = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutorCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutorCases_Executors_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Executors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExecutorCases_LawCases_LawCaseId",
                        column: x => x.LawCaseId,
                        principalTable: "LawCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payee = table.Column<string>(maxLength: 50, nullable: false),
                    ExpenceDescription = table.Column<string>(maxLength: 100, nullable: false),
                    ExpenceValue = table.Column<decimal>(nullable: false),
                    ExpenceDate = table.Column<DateTime>(nullable: false),
                    LawCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_LawCases_LawCaseId",
                        column: x => x.LawCaseId,
                        principalTable: "LawCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseActions_LawCaseId",
                table: "CaseActions",
                column: "LawCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseActions_LegalActionId",
                table: "CaseActions",
                column: "LegalActionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourtCases_CourtId",
                table: "CourtCases",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_CourtCases_LawCaseId",
                table: "CourtCases",
                column: "LawCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_CourtTownId",
                table: "Courts",
                column: "CourtTownId");

            migrationBuilder.CreateIndex(
                name: "IX_Debitors_AbNumber",
                table: "Debitors",
                column: "AbNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutorCases_ExecutorId",
                table: "ExecutorCases",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutorCases_LawCaseId",
                table: "ExecutorCases",
                column: "LawCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_LawCaseId",
                table: "Expenses",
                column: "LawCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AbNumber",
                table: "Invoices",
                column: "AbNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DebitorId",
                table: "Invoices",
                column: "DebitorId");

            migrationBuilder.CreateIndex(
                name: "IX_LawCases_AbNumber",
                table: "LawCases",
                column: "AbNumber");

            migrationBuilder.CreateIndex(
                name: "IX_LawCases_DebitorId",
                table: "LawCases",
                column: "DebitorId");

            migrationBuilder.CreateIndex(
                name: "IX_LawCases_ObligationId",
                table: "LawCases",
                column: "ObligationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ObligationId",
                table: "Payments",
                column: "ObligationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseActions");

            migrationBuilder.DropTable(
                name: "CommonInterestRates");

            migrationBuilder.DropTable(
                name: "CourtCases");

            migrationBuilder.DropTable(
                name: "ExecutorCases");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "LegalActions");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "Executors");

            migrationBuilder.DropTable(
                name: "LawCases");

            migrationBuilder.DropTable(
                name: "CourtTowns");

            migrationBuilder.DropTable(
                name: "Debitors");

            migrationBuilder.DropTable(
                name: "Obligations");

            migrationBuilder.DropTable(
                name: "HeatEstates");
        }
    }
}

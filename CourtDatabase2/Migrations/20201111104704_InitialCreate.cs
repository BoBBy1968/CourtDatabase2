using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtDatabase2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommonInterestRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                name: "LegalActionViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ActionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalActionViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obligations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    MoratoriumInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LegalInterest = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
                    CaseYear = table.Column<int>(nullable: false),
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
                    ExpenceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "LegalActionViewModel");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSis.Migrations
{
    public partial class migrationPublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Secretarias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Acronym = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Login = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    CheckedPassword = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SecretariesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Secretarias_SecretariesId",
                        column: x => x.SecretariesId,
                        principalTable: "Secretarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autorização de Viagem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CurrentYear = table.Column<string>(maxLength: 4, nullable: false),
                    CurrentDate = table.Column<DateTime>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 80, nullable: false),
                    SecretaryName = table.Column<string>(maxLength: 80, nullable: false),
                    Office = table.Column<string>(maxLength: 60, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    DepartureTime = table.Column<string>(maxLength: 5, nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<string>(maxLength: 5, nullable: false),
                    Accountability = table.Column<DateTime>(nullable: false),
                    OneWayTickets = table.Column<int>(nullable: false),
                    ReturnTickets = table.Column<int>(nullable: false),
                    Destiny = table.Column<string>(maxLength: 60, nullable: false),
                    UG = table.Column<double>(nullable: false),
                    UO = table.Column<double>(nullable: false),
                    PA = table.Column<double>(nullable: false),
                    Expanses = table.Column<string>(maxLength: 30, nullable: false),
                    Font = table.Column<int>(nullable: false),
                    FoodQuantity = table.Column<int>(nullable: false),
                    HostingQuantity = table.Column<int>(nullable: false),
                    FoodUnitaryValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    HostingUnitaryValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FoodTotalValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    HostingTotalValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ExpanseTotalValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Goal = table.Column<string>(maxLength: 300, nullable: false),
                    SecretariesId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorização de Viagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autorização de Viagem_Secretarias_SecretariesId",
                        column: x => x.SecretariesId,
                        principalTable: "Secretarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autorização de Viagem_Usuarios_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autorização de Viagem_SecretariesId",
                table: "Autorização de Viagem",
                column: "SecretariesId");

            migrationBuilder.CreateIndex(
                name: "IX_Autorização de Viagem_UsersId",
                table: "Autorização de Viagem",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SecretariesId",
                table: "Usuarios",
                column: "SecretariesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autorização de Viagem");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Secretarias");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitKitApp.Migrations
{
    public partial class InicijalnaFitKit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 30, nullable: true),
                    Prezime = table.Column<string>(maxLength: 30, nullable: true),
                    Visina = table.Column<float>(nullable: false),
                    Tezina = table.Column<float>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Plata = table.Column<float>(nullable: false),
                    Profilna = table.Column<string>(nullable: true),
                    EducationLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ProfilePic = table.Column<string>(nullable: true),
                    Visina = table.Column<int>(nullable: false),
                    Tezina = table.Column<float>(nullable: false),
                    ObemGradi = table.Column<int>(nullable: false),
                    ObemBiceps = table.Column<int>(nullable: false),
                    ObemDesenBiceps = table.Column<int>(nullable: false),
                    ObemStruk = table.Column<int>(nullable: false),
                    ObemLevBut = table.Column<int>(nullable: false),
                    ObemDesenBut = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objekt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Kvadratura = table.Column<int>(nullable: false),
                    Lokacija = table.Column<string>(nullable: true),
                    MaxClients = table.Column<int>(nullable: false),
                    TipVezbanje = table.Column<string>(nullable: true),
                    OtvorZatvor = table.Column<string>(nullable: true),
                    Coach1Id = table.Column<int>(nullable: true),
                    Coach2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objekt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objekt_Coach_Coach1Id",
                        column: x => x.Coach1Id,
                        principalTable: "Coach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objekt_Coach_Coach2Id",
                        column: x => x.Coach2Id,
                        principalTable: "Coach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zaclenuvanje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjektId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Termin = table.Column<DateTime>(nullable: false),
                    OdobrenNeodobren = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaclenuvanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaclenuvanje_Objekt_ObjektId",
                        column: x => x.ObjektId,
                        principalTable: "Objekt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaclenuvanje_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objekt_Coach1Id",
                table: "Objekt",
                column: "Coach1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Objekt_Coach2Id",
                table: "Objekt",
                column: "Coach2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zaclenuvanje_ObjektId",
                table: "Zaclenuvanje",
                column: "ObjektId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaclenuvanje_UserId",
                table: "Zaclenuvanje",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zaclenuvanje");

            migrationBuilder.DropTable(
                name: "Objekt");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Coach");
        }
    }
}

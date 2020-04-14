using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class intialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    CoursId = table.Column<Guid>(nullable: false),
                    designation = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.CoursId);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorId = table.Column<Guid>(nullable: false),
                    nom = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Salle",
                columns: table => new
                {
                    SalleId = table.Column<Guid>(nullable: false),
                    designation = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.SalleId);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    ReservationId = table.Column<Guid>(nullable: false),
                    dateReservation = table.Column<DateTime>(nullable: false),
                    instructorId = table.Column<Guid>(nullable: false),
                    salleId = table.Column<Guid>(nullable: false),
                    coursId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_reservations_Cours_coursId",
                        column: x => x.coursId,
                        principalTable: "Cours",
                        principalColumn: "CoursId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_Instructor_instructorId",
                        column: x => x.instructorId,
                        principalTable: "Instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_Salle_salleId",
                        column: x => x.salleId,
                        principalTable: "Salle",
                        principalColumn: "SalleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_coursId",
                table: "reservations",
                column: "coursId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_instructorId",
                table: "reservations",
                column: "instructorId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_salleId",
                table: "reservations",
                column: "salleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Salle");
        }
    }
}

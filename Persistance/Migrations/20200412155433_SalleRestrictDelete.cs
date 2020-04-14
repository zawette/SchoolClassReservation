using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class SalleRestrictDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_Instructor_instructorId",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_Salle_salleId",
                table: "reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_Instructor_instructorId",
                table: "reservations",
                column: "instructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_Salle_salleId",
                table: "reservations",
                column: "salleId",
                principalTable: "Salle",
                principalColumn: "SalleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_Instructor_instructorId",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_Salle_salleId",
                table: "reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_Instructor_instructorId",
                table: "reservations",
                column: "instructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_Salle_salleId",
                table: "reservations",
                column: "salleId",
                principalTable: "Salle",
                principalColumn: "SalleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

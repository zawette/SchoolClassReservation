using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class noCascadeDeleteSall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_Instructor_instructorId",
                table: "reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_Instructor_instructorId",
                table: "reservations",
                column: "instructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_Instructor_instructorId",
                table: "reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_Instructor_instructorId",
                table: "reservations",
                column: "instructorId",
                principalTable: "Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planning_platform.Data.Migrations
{
    public partial class delete_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
            name: "FK_Classes_Lessons_LessonId",
            table: "Classes");

            migrationBuilder.DropIndex(
            name: "IX_Classes_LessonId",
            table: "Classes");

            migrationBuilder.DropColumn(
            name: "LessonId",
            table: "Classes");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

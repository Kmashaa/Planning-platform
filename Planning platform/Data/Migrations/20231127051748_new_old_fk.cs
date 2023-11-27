using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planning_platform.Data.Migrations
{
    public partial class new_old_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Classes_ClassId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ClassId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "Class_id",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class_id",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ClassId",
                table: "Lessons",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Classes_ClassId",
                table: "Lessons",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }
    }
}

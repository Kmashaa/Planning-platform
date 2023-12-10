using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planning_platform.Migrations
{
    public partial class teacher_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_TeacherId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Lessons",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId1",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId1",
                table: "Lessons",
                column: "TeacherId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_TeacherId1",
                table: "Lessons",
                column: "TeacherId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_TeacherId1",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TeacherId1",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "TeacherId1",
                table: "Lessons");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Lessons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

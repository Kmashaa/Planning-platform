using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planning_platform.Migrations
{
    public partial class addmoderatorid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetUsers_ModeratorId",
                table: "Announcements");

            migrationBuilder.AlterColumn<string>(
                name: "ModeratorId",
                table: "Announcements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetUsers_ModeratorId",
                table: "Announcements",
                column: "ModeratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetUsers_ModeratorId",
                table: "Announcements");

            migrationBuilder.AlterColumn<string>(
                name: "ModeratorId",
                table: "Announcements",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetUsers_ModeratorId",
                table: "Announcements",
                column: "ModeratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

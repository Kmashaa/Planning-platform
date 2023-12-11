using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planning_platform.Migrations
{
    public partial class drop_is_published : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is_publiched",
                table: "Homeworks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Is_publiched",
                table: "Homeworks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

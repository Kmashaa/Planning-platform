using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planning_platform.Migrations
{
    public partial class fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Classes_Classes_ClasId",
            //    table: "Classes");

            //migrationBuilder.DropTable(
            //    name: "ApplicationUserClass");

            //migrationBuilder.DropIndex(
            //    name: "IX_Classes_ClasId",
            //    table: "Classes");

            //migrationBuilder.DropColumn(
            //    name: "ClasId",
            //    table: "Classes");

            //migrationBuilder.DropColumn(
            //    name: "ClassId",
            //    table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Class_id",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClassId",
                table: "AspNetUsers",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classes_ClassId",
                table: "AspNetUsers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classes_ClassId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClassId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Class_id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ClasId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserClass",
                columns: table => new
                {
                    ClassesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserClass", x => new { x.ClassesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserClass_AspNetUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserClass_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClasId",
                table: "Classes",
                column: "ClasId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserClass_StudentsId",
                table: "ApplicationUserClass",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Classes_ClasId",
                table: "Classes",
                column: "ClasId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

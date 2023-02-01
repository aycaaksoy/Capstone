using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class studentsv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentV2StudentId",
                table: "studentCourses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "studentsv2",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StudentRating = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentIDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsv2", x => x.StudentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentCourses_StudentV2StudentId",
                table: "studentCourses",
                column: "StudentV2StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentCourses_studentsv2_StudentV2StudentId",
                table: "studentCourses",
                column: "StudentV2StudentId",
                principalTable: "studentsv2",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentCourses_studentsv2_StudentV2StudentId",
                table: "studentCourses");

            migrationBuilder.DropTable(
                name: "studentsv2");

            migrationBuilder.DropIndex(
                name: "IX_studentCourses_StudentV2StudentId",
                table: "studentCourses");

            migrationBuilder.DropColumn(
                name: "StudentV2StudentId",
                table: "studentCourses");
        }
    }
}

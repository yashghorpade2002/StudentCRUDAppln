using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.EF.Migrations
{
    /// <inheritdoc />
    public partial class addstudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    studentEmail = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    studentDiv = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    contactNumber = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "studentAddress",
                columns: table => new
                {
                    addressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    streetname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    city = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    state = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    pinCode = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentAddress", x => x.addressId);
                    table.ForeignKey(
                        name: "FK_studentAddress_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    subjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.subjectId);
                    table.ForeignKey(
                        name: "FK_subject_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentAddress_StudentId",
                table: "studentAddress",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subject_StudentId",
                table: "subject",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentAddress");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "student");
        }
    }
}

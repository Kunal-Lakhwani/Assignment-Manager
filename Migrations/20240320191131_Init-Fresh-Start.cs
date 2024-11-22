using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_Management.Migrations
{
    /// <inheritdoc />
    public partial class InitFreshStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course_Master",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course_Semester = table.Column<int>(type: "int", nullable: false),
                    Course_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course_Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Master", x => x.Course_ID);
                });

            migrationBuilder.CreateTable(
                name: "Professor_Master",
                columns: table => new
                {
                    Prof_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prof_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prof_MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prof_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prof_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prof_salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prof_hash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor_Master", x => x.Prof_ID);
                });

            migrationBuilder.CreateTable(
                name: "Student_Master",
                columns: table => new
                {
                    Student_PRN = table.Column<long>(type: "bigint", nullable: false),
                    Student_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_hash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Master", x => x.Student_PRN);
                });

            migrationBuilder.CreateTable(
                name: "Assignment_master",
                columns: table => new
                {
                    Assignment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    ProfessorID = table.Column<int>(type: "int", nullable: false),
                    Assigned_by_prof = table.Column<int>(type: "int", nullable: false),
                    Assignment_No = table.Column<int>(type: "int", nullable: false),
                    Assignment_Type = table.Column<int>(type: "int", nullable: false),
                    Assignment_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assignment_Descrip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assigned_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment_master", x => x.Assignment_ID);
                    table.ForeignKey(
                        name: "FK_Assignment_master_Course_Master_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course_Master",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_master_Professor_Master_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professor_Master",
                        principalColumn: "Prof_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course_Professors",
                columns: table => new
                {
                    CourseProf_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prof_CourseID = table.Column<int>(type: "int", nullable: false),
                    ProfessorID = table.Column<int>(type: "int", nullable: false),
                    Course_Prof = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Professors", x => x.CourseProf_ID);
                    table.ForeignKey(
                        name: "FK_Course_Professors_Course_Master_Prof_CourseID",
                        column: x => x.Prof_CourseID,
                        principalTable: "Course_Master",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Professors_Professor_Master_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professor_Master",
                        principalColumn: "Prof_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course_Students",
                columns: table => new
                {
                    Course_Enrolled_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enrolled_CourseID = table.Column<int>(type: "int", nullable: false),
                    Enrolled_PRN = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Students", x => x.Course_Enrolled_ID);
                    table.ForeignKey(
                        name: "FK_Course_Students_Course_Master_Enrolled_CourseID",
                        column: x => x.Enrolled_CourseID,
                        principalTable: "Course_Master",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Students_Student_Master_Enrolled_PRN",
                        column: x => x.Enrolled_PRN,
                        principalTable: "Student_Master",
                        principalColumn: "Student_PRN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment_Images",
                columns: table => new
                {
                    Image_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentsId = table.Column<int>(type: "int", nullable: false),
                    Img_AssignID = table.Column<int>(type: "int", nullable: false),
                    Img_FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment_Images", x => x.Image_ID);
                    table.ForeignKey(
                        name: "FK_Assignment_Images_Assignment_master_AssignmentsId",
                        column: x => x.AssignmentsId,
                        principalTable: "Assignment_master",
                        principalColumn: "Assignment_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentsId = table.Column<int>(type: "int", nullable: false),
                    Assign_ID = table.Column<int>(type: "int", nullable: false),
                    StudentPRN = table.Column<long>(type: "bigint", nullable: false),
                    Student_PRN = table.Column<long>(type: "bigint", nullable: false),
                    Submitted_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Submission_FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Submissions_Assignment_master_AssignmentsId",
                        column: x => x.AssignmentsId,
                        principalTable: "Assignment_master",
                        principalColumn: "Assignment_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Student_Master_StudentPRN",
                        column: x => x.StudentPRN,
                        principalTable: "Student_Master",
                        principalColumn: "Student_PRN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_Images_AssignmentsId",
                table: "Assignment_Images",
                column: "AssignmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_master_CourseID",
                table: "Assignment_master",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_master_ProfessorID",
                table: "Assignment_master",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Professors_Prof_CourseID",
                table: "Course_Professors",
                column: "Prof_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Professors_ProfessorID",
                table: "Course_Professors",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Students_Enrolled_CourseID",
                table: "Course_Students",
                column: "Enrolled_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Students_Enrolled_PRN",
                table: "Course_Students",
                column: "Enrolled_PRN");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_AssignmentsId",
                table: "Submissions",
                column: "AssignmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_StudentPRN",
                table: "Submissions",
                column: "StudentPRN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignment_Images");

            migrationBuilder.DropTable(
                name: "Course_Professors");

            migrationBuilder.DropTable(
                name: "Course_Students");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "Assignment_master");

            migrationBuilder.DropTable(
                name: "Student_Master");

            migrationBuilder.DropTable(
                name: "Course_Master");

            migrationBuilder.DropTable(
                name: "Professor_Master");
        }
    }
}

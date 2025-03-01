using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment02.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataBaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Top_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Topics_Top_ID",
                        column: x => x.Top_ID,
                        principalTable: "Topics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseInstructors",
                columns: table => new
                {
                    Inst_ID = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Evaluate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstructors", x => new { x.Inst_ID, x.Course_ID });
                    table.ForeignKey(
                        name: "FK_CourseInstructors_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ins_ID = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dept_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_Department_Dept_ID",
                        column: x => x.Dept_ID,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StudentLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Dep_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Department_Dep_Id",
                        column: x => x.Dep_Id,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudCourses",
                columns: table => new
                {
                    Stud_ID = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudCourses", x => new { x.Stud_ID, x.Course_ID });
                    table.ForeignKey(
                        name: "FK_StudCourses_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudCourses_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Top_ID",
                table: "Course",
                column: "Top_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructors_CourseId",
                table: "CourseInstructors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructors_InstructorId",
                table: "CourseInstructors",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_InstructorId",
                table: "Department",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_Dept_ID",
                table: "Instructor",
                column: "Dept_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StudCourses_CourseId",
                table: "StudCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudCourses_StudentID",
                table: "StudCourses",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Dep_Id",
                table: "Student",
                column: "Dep_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructors_Instructor_InstructorId",
                table: "CourseInstructors",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_InstructorId",
                table: "Department",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_InstructorId",
                table: "Department");

            migrationBuilder.DropTable(
                name: "CourseInstructors");

            migrationBuilder.DropTable(
                name: "StudCourses");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
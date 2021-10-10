using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: true),
                    OrderNumber = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SubjectName = table.Column<string>(maxLength: 50, nullable: true),
                    NumberOfPeriod = table.Column<int>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TeacherName = table.Column<string>(maxLength: 50, nullable: true),
                    TeacherEmail = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TeacherPhone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TeacherGender = table.Column<string>(maxLength: 50, nullable: true),
                    TeacherImage = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    OrderNumber = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SectionName = table.Column<string>(maxLength: 50, nullable: true),
                    NumberOfSession = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Sections_Tbl_Departments",
                        column: x => x.DepartmentId,
                        principalTable: "Tbl_Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ClassName = table.Column<string>(maxLength: 50, nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Classes_Tbl_Departments",
                        column: x => x.DepartmentId,
                        principalTable: "Tbl_Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Classes_Tbl_Teachers",
                        column: x => x.TeacherId,
                        principalTable: "Tbl_Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true),
                    ClassId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNumber = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Schedules_Tbl_Classes",
                        column: x => x.ClassId,
                        principalTable: "Tbl_Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Schedules_Tbl_Subjects",
                        column: x => x.SubjectId,
                        principalTable: "Tbl_Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Schedules_Tbl_Teachers",
                        column: x => x.TeacherId,
                        principalTable: "Tbl_Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    StudentName = table.Column<string>(maxLength: 50, nullable: true),
                    StudentEmail = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    StudentPhone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    StudentGender = table.Column<string>(maxLength: 50, nullable: true),
                    StudentImage = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ClassId = table.Column<int>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Students_Tbl_Classes",
                        column: x => x.ClassId,
                        principalTable: "Tbl_Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: true),
                    Present = table.Column<bool>(nullable: true),
                    Absent = table.Column<bool>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Attendances_Tbl_Students",
                        column: x => x.StudentId,
                        principalTable: "Tbl_Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Attendances_StudentId",
                table: "Tbl_Attendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Classes_DepartmentId",
                table: "Tbl_Classes",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Classes_TeacherId",
                table: "Tbl_Classes",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Schedules_ClassId",
                table: "Tbl_Schedules",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Schedules_SubjectId",
                table: "Tbl_Schedules",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Schedules_TeacherId",
                table: "Tbl_Schedules",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Sections_DepartmentId",
                table: "Tbl_Sections",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Students_ClassId",
                table: "Tbl_Students",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Attendances");

            migrationBuilder.DropTable(
                name: "Tbl_Schedules");

            migrationBuilder.DropTable(
                name: "Tbl_Sections");

            migrationBuilder.DropTable(
                name: "Tbl_Students");

            migrationBuilder.DropTable(
                name: "Tbl_Subjects");

            migrationBuilder.DropTable(
                name: "Tbl_Classes");

            migrationBuilder.DropTable(
                name: "Tbl_Departments");

            migrationBuilder.DropTable(
                name: "Tbl_Teachers");
        }
    }
}

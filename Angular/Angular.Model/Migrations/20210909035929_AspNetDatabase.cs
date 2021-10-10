using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Model.Migrations
{
    public partial class AspNetDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_StudentSubject",
                columns: table => new
                {
                    StudentSubjectCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    OrderNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_StudentSubject", x => x.StudentSubjectCode);
                    table.ForeignKey(
                        name: "FK_Tbl_Students_Tbl_StudentSubject",
                        column: x => x.StudentId,
                        principalTable: "Tbl_Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Subjects_Tbl_StudentSubject",
                        column: x => x.SubjectId,
                        principalTable: "Tbl_Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_StudentSubject_StudentId",
                table: "Tbl_StudentSubject",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_StudentSubject_SubjectId",
                table: "Tbl_StudentSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_StudentSubject");
        }
    }
}

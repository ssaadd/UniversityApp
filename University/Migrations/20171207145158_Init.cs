using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace University.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameFaculty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfDisciplins",
                columns: table => new
                {
                    TypeOfDisciplineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameTypeOfDiscipline = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfDisciplins", x => x.TypeOfDisciplineID);
                });

            migrationBuilder.CreateTable(
                name: "Pulpits",
                columns: table => new
                {
                    PulpitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacultyID = table.Column<int>(type: "int", nullable: false),
                    KindOfChair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamePulpit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pulpits", x => x.PulpitID);
                    table.ForeignKey(
                        name: "FK_Pulpits_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speciaties",
                columns: table => new
                {
                    SpecialtyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Course = table.Column<int>(type: "int", nullable: false),
                    NameSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PulpitID = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciaties", x => x.SpecialtyID);
                    table.ForeignKey(
                        name: "FK_Speciaties_Pulpits_PulpitID",
                        column: x => x.PulpitID,
                        principalTable: "Pulpits",
                        principalColumn: "PulpitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplins",
                columns: table => new
                {
                    DisciplineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameDiscipline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfHoursOfLectures = table.Column<int>(type: "int", nullable: false),
                    NumberOfHoursOfPractice = table.Column<int>(type: "int", nullable: false),
                    SpecialtyID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    TypeOfDisciplineID = table.Column<int>(type: "int", nullable: false),
                    TypeOfRporting = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplins", x => x.DisciplineID);
                    table.ForeignKey(
                        name: "FK_Disciplins_Speciaties_SpecialtyID",
                        column: x => x.SpecialtyID,
                        principalTable: "Speciaties",
                        principalColumn: "SpecialtyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplins_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplins_TypeOfDisciplins_TypeOfDisciplineID",
                        column: x => x.TypeOfDisciplineID,
                        principalTable: "TypeOfDisciplins",
                        principalColumn: "TypeOfDisciplineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplins_SpecialtyID",
                table: "Disciplins",
                column: "SpecialtyID");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplins_TeacherID",
                table: "Disciplins",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplins_TypeOfDisciplineID",
                table: "Disciplins",
                column: "TypeOfDisciplineID");

            migrationBuilder.CreateIndex(
                name: "IX_Pulpits_FacultyID",
                table: "Pulpits",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Speciaties_PulpitID",
                table: "Speciaties",
                column: "PulpitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disciplins");

            migrationBuilder.DropTable(
                name: "Speciaties");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "TypeOfDisciplins");

            migrationBuilder.DropTable(
                name: "Pulpits");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}

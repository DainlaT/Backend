using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.DB.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "faculties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    faculty_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__facultie__3213E83FBE3BA22C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    role_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__roles__3213E83F52C644FD", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    status_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__statuses__3213E83FA5731117", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    faculty_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__departme__3213E83FFB9E7FCC", x => x.id);
                    table.ForeignKey(
                        name: "FK__departmen__facul__5DCAEF64",
                        column: x => x.faculty_id,
                        principalTable: "faculties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    faculty_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83F341FD6DD", x => x.id);
                    table.ForeignKey(
                        name: "FK__users__faculty_i__5AEE82B9",
                        column: x => x.faculty_id,
                        principalTable: "faculties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__users__role_id__59063A47",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__users__status_id__59FA5E80",
                        column: x => x.status_id,
                        principalTable: "statuses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "disciplines",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__discipli__3213E83F3A8C89D4", x => x.id);
                    table.ForeignKey(
                        name: "FK__disciplin__depar__66603565",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "study_programs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: true),
                    cypher_of_the_direction = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__study_pr__3213E83FF4D1F0A8", x => x.id);
                    table.ForeignKey(
                        name: "FK__study_pro__depar__60A75C0F",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discipline_teacher",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    discipline_id = table.Column<int>(type: "int", nullable: true),
                    responsible_teacher_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__discipli__3213E83F12EC2320", x => x.id);
                    table.ForeignKey(
                        name: "FK__disciplin__disci__797309D9",
                        column: x => x.discipline_id,
                        principalTable: "disciplines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__disciplin__respo__7A672E12",
                        column: x => x.responsible_teacher_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    discipline_id = table.Column<int>(type: "int", nullable: true),
                    teacher_id = table.Column<int>(type: "int", nullable: true),
                    file_path = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    is_correct = table.Column<byte>(type: "tinyint", nullable: true),
                    result_of_attestation = table.Column<string>(type: "text", nullable: true),
                    done_in_paper_form = table.Column<byte>(type: "tinyint", nullable: true),
                    done_in_electronic_form = table.Column<byte>(type: "tinyint", nullable: true),
                    all_done = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reports__3213E83FF39C3E5E", x => x.id);
                    table.ForeignKey(
                        name: "FK__reports__discipl__693CA210",
                        column: x => x.discipline_id,
                        principalTable: "disciplines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__reports__teacher__6A30C649",
                        column: x => x.teacher_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "study_groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    group_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    study_program_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__study_gr__3213E83F1205F8C9", x => x.id);
                    table.ForeignKey(
                        name: "FK__study_gro__study__6383C8BA",
                        column: x => x.study_program_id,
                        principalTable: "study_programs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "testing",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: true),
                    discipline_id = table.Column<int>(type: "int", nullable: true),
                    scheduled_date = table.Column<DateOnly>(type: "date", nullable: true),
                    scheduled_time = table.Column<TimeOnly>(type: "time", nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    result_of_testing = table.Column<string>(type: "text", nullable: true),
                    report_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__testing__3213E83FEC9AF393", x => x.id);
                    table.ForeignKey(
                        name: "FK__testing__discipl__75A278F5",
                        column: x => x.discipline_id,
                        principalTable: "disciplines",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__testing__group_i__74AE54BC",
                        column: x => x.group_id,
                        principalTable: "study_groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__testing__report___76969D2E",
                        column: x => x.report_id,
                        principalTable: "reports",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments_faculty_id",
                table: "departments",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "IX_discipline_teacher_discipline_id",
                table: "discipline_teacher",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_discipline_teacher_responsible_teacher_id",
                table: "discipline_teacher",
                column: "responsible_teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_disciplines_department_id",
                table: "disciplines",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_reports_discipline_id",
                table: "reports",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_reports_teacher_id",
                table: "reports",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_study_groups_study_program_id",
                table: "study_groups",
                column: "study_program_id");

            migrationBuilder.CreateIndex(
                name: "IX_study_programs_department_id",
                table: "study_programs",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_testing_discipline_id",
                table: "testing",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_testing_group_id",
                table: "testing",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_testing_report_id",
                table: "testing",
                column: "report_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_faculty_id",
                table: "users",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_status_id",
                table: "users",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "UQ__users__AB6E6164A645B7AF",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "discipline_teacher");

            migrationBuilder.DropTable(
                name: "testing");

            migrationBuilder.DropTable(
                name: "study_groups");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "study_programs");

            migrationBuilder.DropTable(
                name: "disciplines");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "faculties");
        }
    }
}

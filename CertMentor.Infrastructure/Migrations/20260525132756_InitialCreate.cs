using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertMentor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IsPass = table.Column<bool>(type: "bit", nullable: true),
                    Score = table.Column<float>(type: "real", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CertificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamSessions_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LowestWeightPercentage = table.Column<int>(type: "int", nullable: true),
                    HighestWeightPercentage = table.Column<int>(type: "int", nullable: true),
                    CertificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillAreas_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    ExamSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceRecords_ExamSessions_ExamSessionId",
                        column: x => x.ExamSessionId,
                        principalTable: "ExamSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    SkillAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_SkillAreas_SkillAreaId",
                        column: x => x.SkillAreaId,
                        principalTable: "SkillAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillAreaScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<float>(type: "real", nullable: false),
                    SkillAreaId = table.Column<int>(type: "int", nullable: false),
                    PerformanceRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillAreaScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillAreaScores_PerformanceRecords_PerformanceRecordId",
                        column: x => x.PerformanceRecordId,
                        principalTable: "PerformanceRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillAreaScores_SkillAreas_SkillAreaId",
                        column: x => x.SkillAreaId,
                        principalTable: "SkillAreas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudyPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformanceRecordId = table.Column<int>(type: "int", nullable: false),
                    CertificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPlans_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudyPlans_PerformanceRecords_PerformanceRecordId",
                        column: x => x.PerformanceRecordId,
                        principalTable: "PerformanceRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ExamSessionId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    Answers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_ExamSessions_ExamSessionId",
                        column: x => x.ExamSessionId,
                        principalTable: "ExamSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudyPlanItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MicrosoftLearnUnit = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    TimeInMinutes = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    StudyPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPlanItems_StudyPlans_StudyPlanId",
                        column: x => x.StudyPlanId,
                        principalTable: "StudyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExamQuestionId = table.Column<int>(type: "int", nullable: false),
                    Answers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_ExamQuestions_ExamQuestionId",
                        column: x => x.ExamQuestionId,
                        principalTable: "ExamQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamSessionId",
                table: "ExamQuestions",
                column: "ExamSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_TopicId",
                table: "ExamQuestions",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSessions_CertificationId",
                table: "ExamSessions",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceRecords_ExamSessionId",
                table: "PerformanceRecords",
                column: "ExamSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillAreas_CertificationId",
                table: "SkillAreas",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillAreaScores_PerformanceRecordId",
                table: "SkillAreaScores",
                column: "PerformanceRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillAreaScores_SkillAreaId",
                table: "SkillAreaScores",
                column: "SkillAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanItems_StudyPlanId",
                table: "StudyPlanItems",
                column: "StudyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_CertificationId",
                table: "StudyPlans",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_PerformanceRecordId",
                table: "StudyPlans",
                column: "PerformanceRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_SkillAreaId",
                table: "Topics",
                column: "SkillAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_ExamQuestionId",
                table: "UserAnswers",
                column: "ExamQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillAreaScores");

            migrationBuilder.DropTable(
                name: "StudyPlanItems");

            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropTable(
                name: "StudyPlans");

            migrationBuilder.DropTable(
                name: "ExamQuestions");

            migrationBuilder.DropTable(
                name: "PerformanceRecords");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "ExamSessions");

            migrationBuilder.DropTable(
                name: "SkillAreas");

            migrationBuilder.DropTable(
                name: "Certifications");
        }
    }
}

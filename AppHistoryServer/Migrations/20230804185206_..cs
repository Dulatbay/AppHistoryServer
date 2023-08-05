using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppHistoryServer.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Module_ModuleId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Module_ModuleId",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                table: "Module");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "Modules");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "Question",
                newName: "ArchiveBookId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_ModuleId",
                table: "Question",
                newName: "IX_Question_ArchiveBookId");

            migrationBuilder.AddColumn<DateTime>(
                name: "createAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Question",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CorrectVarianIndex",
                table: "Question",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                table: "Question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Question",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ArchiveBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Downloads = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveBook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateNumber = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TopicId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dates_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassedUserQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    ChooseIndex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedUserQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassedUserQuestions_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassedUserQuestions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassedUserTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TopicId = table.Column<int>(type: "integer", nullable: false),
                    PassedPercent = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedUserTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassedUserTopics_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassedUserTopics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quiz_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Term",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TermText = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TopicId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Term", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Term_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoritedUserQuizzes",
                columns: table => new
                {
                    AddedFavoritedUsersId = table.Column<int>(type: "integer", nullable: false),
                    FavoritedQuizzesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritedUserQuizzes", x => new { x.AddedFavoritedUsersId, x.FavoritedQuizzesId });
                    table.ForeignKey(
                        name: "FK_FavoritedUserQuizzes_Quiz_FavoritedQuizzesId",
                        column: x => x.FavoritedQuizzesId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritedUserQuizzes_Users_AddedFavoritedUsersId",
                        column: x => x.AddedFavoritedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassedUserQuizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    QuizId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedUserQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassedUserQuizzes_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassedUserQuizzes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionQuiz",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "integer", nullable: false),
                    QuizzesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionQuiz", x => new { x.QuestionsId, x.QuizzesId });
                    table.ForeignKey(
                        name: "FK_QuestionQuiz_Question_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionQuiz_Quiz_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionVariant",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "integer", nullable: false),
                    VariantsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionVariant", x => new { x.QuestionsId, x.VariantsId });
                    table.ForeignKey(
                        name: "FK_QuestionVariant_Question_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionVariant_Variant_VariantsId",
                        column: x => x.VariantsId,
                        principalTable: "Variant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassedUserQuestionsPassedUserQuizzes",
                columns: table => new
                {
                    PassedQuestionsId = table.Column<int>(type: "integer", nullable: false),
                    PassedUserQuizzesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedUserQuestionsPassedUserQuizzes", x => new { x.PassedQuestionsId, x.PassedUserQuizzesId });
                    table.ForeignKey(
                        name: "FK_PassedUserQuestionsPassedUserQuizzes_PassedUserQuestions_Pa~",
                        column: x => x.PassedQuestionsId,
                        principalTable: "PassedUserQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassedUserQuestionsPassedUserQuizzes_PassedUserQuizzes_Pass~",
                        column: x => x.PassedUserQuizzesId,
                        principalTable: "PassedUserQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_AuthorId",
                table: "Question",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_TopicId",
                table: "Question",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Dates_TopicId",
                table: "Dates",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedUserQuizzes_FavoritedQuizzesId",
                table: "FavoritedUserQuizzes",
                column: "FavoritedQuizzesId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedUserQuestions_QuestionId",
                table: "PassedUserQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedUserQuestions_UserId",
                table: "PassedUserQuestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedUserQuestionsPassedUserQuizzes_PassedUserQuizzesId",
                table: "PassedUserQuestionsPassedUserQuizzes",
                column: "PassedUserQuizzesId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedUserQuizzes_QuizId",
                table: "PassedUserQuizzes",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedUserQuizzes_UserId",
                table: "PassedUserQuizzes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedUserTopics_TopicId",
                table: "PassedUserTopics",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedUserTopics_UserId",
                table: "PassedUserTopics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionQuiz_QuizzesId",
                table: "QuestionQuiz",
                column: "QuizzesId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVariant_VariantsId",
                table: "QuestionVariant",
                column: "VariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_AuthorId",
                table: "Quiz",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Term_TopicId",
                table: "Term",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ArchiveBook_ArchiveBookId",
                table: "Question",
                column: "ArchiveBookId",
                principalTable: "ArchiveBook",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Topic_TopicId",
                table: "Question",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Users_AuthorId",
                table: "Question",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Modules_ModuleId",
                table: "Topic",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_ArchiveBook_ArchiveBookId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Topic_TopicId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Users_AuthorId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Modules_ModuleId",
                table: "Topic");

            migrationBuilder.DropTable(
                name: "ArchiveBook");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "FavoritedUserQuizzes");

            migrationBuilder.DropTable(
                name: "PassedUserQuestionsPassedUserQuizzes");

            migrationBuilder.DropTable(
                name: "PassedUserTopics");

            migrationBuilder.DropTable(
                name: "QuestionQuiz");

            migrationBuilder.DropTable(
                name: "QuestionVariant");

            migrationBuilder.DropTable(
                name: "Term");

            migrationBuilder.DropTable(
                name: "PassedUserQuestions");

            migrationBuilder.DropTable(
                name: "PassedUserQuizzes");

            migrationBuilder.DropTable(
                name: "Variant");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Question_AuthorId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_TopicId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "createAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CorrectVarianIndex",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuestionText",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "Module");

            migrationBuilder.RenameColumn(
                name: "ArchiveBookId",
                table: "Question",
                newName: "ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_ArchiveBookId",
                table: "Question",
                newName: "IX_Question_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                table: "Module",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Module_ModuleId",
                table: "Question",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Module_ModuleId",
                table: "Topic",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

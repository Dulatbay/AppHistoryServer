using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHistoryServer.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_AuthorId",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Variants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Quizzes",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "Questions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Questions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Modules",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Description", "ImageUrl", "Level", "Minutes", "Number", "Title" },
                values: new object[] { 1, "Test", null, 1, 10, 1, "Test" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "ContentId", "ModuleId", "Number", "Title" },
                values: new object[] { 1, 1, 1, 1, "Test" });

            migrationBuilder.InsertData(
                table: "Node",
                columns: new[] { "Id", "Component", "TopicId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_AuthorId",
                table: "Questions",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_AuthorId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Node",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Modules");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Variants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_AuthorId",
                table: "Questions",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

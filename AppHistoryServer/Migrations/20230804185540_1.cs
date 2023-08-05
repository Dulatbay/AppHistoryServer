using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHistoryServer.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Topic_lastTopicId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Quiz");

            migrationBuilder.RenameColumn(
                name: "lastTopicId",
                table: "Users",
                newName: "LastTopicId");

            migrationBuilder.RenameColumn(
                name: "createAt",
                table: "Users",
                newName: "CreateAt");

            migrationBuilder.RenameIndex(
                name: "IX_Users_lastTopicId",
                table: "Users",
                newName: "IX_Users_LastTopicId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "League",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Quiz",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Topic_LastTopicId",
                table: "Users",
                column: "LastTopicId",
                principalTable: "Topic",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Topic_LastTopicId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Quiz");

            migrationBuilder.RenameColumn(
                name: "LastTopicId",
                table: "Users",
                newName: "lastTopicId");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Users",
                newName: "createAt");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LastTopicId",
                table: "Users",
                newName: "IX_Users_lastTopicId");

            migrationBuilder.AlterColumn<int>(
                name: "League",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Quiz",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Topic_lastTopicId",
                table: "Users",
                column: "lastTopicId",
                principalTable: "Topic",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class ChangeMemberCharToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MemberCharacter",
                table: "Members",
                type: "varchar(1) CHARACTER SET utf8mb4",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1) CHARACTER SET utf8mb4",
                oldMaxLength: 1);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 1,
                column: "GroupCreated",
                value: new DateTime(2022, 10, 25, 18, 56, 1, 824, DateTimeKind.Utc).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 2,
                column: "GroupCreated",
                value: new DateTime(2022, 10, 25, 18, 56, 1, 824, DateTimeKind.Utc).AddTicks(954));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 3,
                column: "GroupCreated",
                value: new DateTime(2022, 10, 25, 18, 56, 1, 824, DateTimeKind.Utc).AddTicks(957));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "MemberCreated",
                value: new DateTime(2022, 10, 25, 18, 56, 1, 824, DateTimeKind.Utc).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "MemberCreated",
                value: new DateTime(2022, 10, 25, 18, 56, 1, 824, DateTimeKind.Utc).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "MessageCreated",
                value: new DateTime(2022, 10, 25, 18, 56, 1, 822, DateTimeKind.Utc).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "MessageCreated",
                value: new DateTime(2022, 10, 25, 18, 56, 1, 823, DateTimeKind.Utc).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "MessageCreated",
                value: new DateTime(2022, 10, 25, 18, 56, 1, 823, DateTimeKind.Utc).AddTicks(606));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MemberCharacter",
                table: "Members",
                type: "varchar(1) CHARACTER SET utf8mb4",
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(1) CHARACTER SET utf8mb4",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 1,
                column: "GroupCreated",
                value: new DateTime(2022, 10, 25, 9, 37, 39, 551, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 2,
                column: "GroupCreated",
                value: new DateTime(2022, 10, 25, 9, 37, 39, 551, DateTimeKind.Local).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 3,
                column: "GroupCreated",
                value: new DateTime(2022, 10, 25, 9, 37, 39, 551, DateTimeKind.Local).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "MemberCreated",
                value: new DateTime(2022, 10, 25, 9, 37, 39, 551, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "MemberCreated",
                value: new DateTime(2022, 10, 25, 9, 37, 39, 551, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "MessageCreated",
                value: new DateTime(2022, 10, 25, 16, 37, 39, 550, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "MessageCreated",
                value: new DateTime(2022, 10, 25, 16, 37, 39, 550, DateTimeKind.Utc).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "MessageCreated",
                value: new DateTime(2022, 10, 25, 16, 37, 39, 550, DateTimeKind.Utc).AddTicks(7458));
        }
    }
}

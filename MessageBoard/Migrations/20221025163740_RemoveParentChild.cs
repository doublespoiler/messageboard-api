using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class RemoveParentChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GroupTitle = table.Column<string>(type: "varchar(25) CHARACTER SET utf8mb4", maxLength: 25, nullable: false),
                    GroupTopic = table.Column<string>(type: "varchar(25) CHARACTER SET utf8mb4", maxLength: 25, nullable: true),
                    GroupColor = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    GroupCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberName = table.Column<string>(type: "varchar(25) CHARACTER SET utf8mb4", maxLength: 25, nullable: false),
                    MemberCharacter = table.Column<string>(type: "varchar(1) CHARACTER SET utf8mb4", maxLength: 1, nullable: false),
                    MemberColor = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    MemberCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "GroupMember",
                columns: table => new
                {
                    GroupMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => x.GroupMemberId);
                    table.ForeignKey(
                        name: "FK_GroupMember_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMember_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MessageTitle = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: true),
                    MessageText = table.Column<string>(type: "varchar(999) CHARACTER SET utf8mb4", maxLength: 999, nullable: false),
                    MessageCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupMessage",
                columns: table => new
                {
                    GroupMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMessage", x => x.GroupMessageId);
                    table.ForeignKey(
                        name: "FK_GroupMessage_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMessage_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberMessage",
                columns: table => new
                {
                    MemberMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberMessage", x => x.MemberMessageId);
                    table.ForeignKey(
                        name: "FK_MemberMessage_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberMessage_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupColor", "GroupCreated", "GroupTitle", "GroupTopic" },
                values: new object[,]
                {
                    { 1, "#fff", new DateTime(2022, 10, 25, 9, 37, 39, 551, DateTimeKind.Local).AddTicks(6787), "Main", "This is the main group" },
                    { 2, "#ff0000", new DateTime(2022, 10, 25, 9, 37, 39, 551, DateTimeKind.Local).AddTicks(7624), "Nintendo", "Nintendo Switch" },
                    { 3, "#00ff00", new DateTime(2022, 10, 25, 9, 37, 39, 551, DateTimeKind.Local).AddTicks(7629), "Programming", "For Programmers" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "MemberCharacter", "MemberColor", "MemberCreated", "MemberName" },
                values: new object[,]
                {
                    { 1, "S", "#ff8000", new DateTime(2022, 10, 25, 9, 37, 39, 551, DateTimeKind.Local).AddTicks(8598), "Skylan" },
                    { 2, "W", "#0000ff", new DateTime(2022, 10, 25, 9, 37, 39, 551, DateTimeKind.Local).AddTicks(9600), "Will" }
                });

            migrationBuilder.InsertData(
                table: "GroupMember",
                columns: new[] { "GroupMemberId", "GroupId", "MemberId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 4, 3, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "GroupId", "MemberId", "MessageCreated", "MessageText", "MessageTitle" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 10, 25, 16, 37, 39, 550, DateTimeKind.Utc).AddTicks(6304), "Hello World", "Hello World" },
                    { 2, 1, 2, new DateTime(2022, 10, 25, 16, 37, 39, 550, DateTimeKind.Utc).AddTicks(7454), "Goodbye World", "Goodbye World" },
                    { 3, 2, 2, new DateTime(2022, 10, 25, 16, 37, 39, 550, DateTimeKind.Utc).AddTicks(7458), "Nintendo", "Nintendo Switch" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_GroupId",
                table: "GroupMember",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_MemberId",
                table: "GroupMember",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessage_GroupId",
                table: "GroupMessage",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessage_MessageId",
                table: "GroupMessage",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberMessage_MemberId",
                table: "MemberMessage",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberMessage_MessageId",
                table: "MemberMessage",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_GroupId",
                table: "Messages",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MemberId",
                table: "Messages",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropTable(
                name: "GroupMessage");

            migrationBuilder.DropTable(
                name: "MemberMessage");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}

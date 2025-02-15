using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deepin.Chatting.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "chatting");

            migrationBuilder.CreateTable(
                name: "chats",
                schema: "chatting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    avatar_file_id = table.Column<string>(type: "text", nullable: true),
                    is_public = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chats", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chat_members",
                schema: "chatting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: true),
                    joined_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    chat_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_members", x => x.id);
                    table.ForeignKey(
                        name: "FK_chat_members_chats_chat_id",
                        column: x => x.chat_id,
                        principalSchema: "chatting",
                        principalTable: "chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat_read_statuses",
                schema: "chatting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    chat_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    last_read_message_id = table.Column<string>(type: "text", nullable: false),
                    last_read_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_read_statuses", x => x.id);
                    table.ForeignKey(
                        name: "FK_chat_read_statuses_chats_chat_id",
                        column: x => x.chat_id,
                        principalSchema: "chatting",
                        principalTable: "chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chat_members_chat_id",
                schema: "chatting",
                table: "chat_members",
                column: "chat_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_read_statuses_chat_id",
                schema: "chatting",
                table: "chat_read_statuses",
                column: "chat_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_members",
                schema: "chatting");

            migrationBuilder.DropTable(
                name: "chat_read_statuses",
                schema: "chatting");

            migrationBuilder.DropTable(
                name: "chats",
                schema: "chatting");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatNext.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "filestorages",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    filetype = table.Column<string>(type: "TEXT", nullable: false),
                    size = table.Column<long>(type: "INTEGER", nullable: false),
                    savemode = table.Column<string>(type: "TEXT", nullable: false),
                    data = table.Column<string>(type: "TEXT", nullable: false),
                    createdat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    creator = table.Column<Guid>(type: "TEXT", nullable: true),
                    updatedat = table.Column<DateTime>(type: "TEXT", nullable: true),
                    modifier = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filestorages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "TEXT", nullable: false),
                    role = table.Column<string>(type: "TEXT", nullable: false),
                    sessionid = table.Column<long>(type: "INTEGER", nullable: false),
                    frommodel = table.Column<string>(type: "TEXT", nullable: false),
                    files = table.Column<string>(type: "TEXT", nullable: false),
                    plugin = table.Column<string>(type: "TEXT", nullable: false),
                    parentid = table.Column<string>(type: "TEXT", nullable: true),
                    createdat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    creator = table.Column<Guid>(type: "TEXT", nullable: true),
                    updatedat = table.Column<DateTime>(type: "TEXT", nullable: true),
                    modifier = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "plugins",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    identifier = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    avatar = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    tags = table.Column<string>(type: "TEXT", nullable: false),
                    version = table.Column<string>(type: "TEXT", nullable: false),
                    systemrole = table.Column<string>(type: "TEXT", nullable: false),
                    functionname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plugins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sessiongroups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    sort = table.Column<int>(type: "INTEGER", nullable: false),
                    isdefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    createdat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    creator = table.Column<Guid>(type: "TEXT", nullable: true),
                    updatedat = table.Column<DateTime>(type: "TEXT", nullable: true),
                    modifier = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessiongroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sessions",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    groupid = table.Column<Guid>(type: "TEXT", nullable: false),
                    pinned = table.Column<bool>(type: "INTEGER", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    config = table.Column<string>(type: "TEXT", nullable: false),
                    avatar = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    tags = table.Column<string>(type: "TEXT", nullable: false),
                    model = table.Column<string>(type: "TEXT", nullable: false),
                    provider = table.Column<string>(type: "TEXT", nullable: false),
                    systemrole = table.Column<string>(type: "TEXT", nullable: false),
                    topp = table.Column<float>(type: "REAL", nullable: false),
                    temperature = table.Column<float>(type: "REAL", nullable: false),
                    presencepenalty = table.Column<float>(type: "REAL", nullable: false),
                    historylimit = table.Column<int>(type: "INTEGER", nullable: false),
                    plugins = table.Column<string>(type: "TEXT", nullable: false),
                    createdat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    creator = table.Column<Guid>(type: "TEXT", nullable: true),
                    updatedat = table.Column<DateTime>(type: "TEXT", nullable: true),
                    modifier = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "useroauthextensions",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userid = table.Column<string>(type: "TEXT", nullable: false),
                    provider = table.Column<string>(type: "TEXT", nullable: false),
                    providerkey = table.Column<string>(type: "TEXT", nullable: false),
                    extra = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_useroauthextensions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    passwordsalt = table.Column<string>(type: "TEXT", nullable: false),
                    avatar = table.Column<string>(type: "TEXT", nullable: false),
                    state = table.Column<byte>(type: "INTEGER", nullable: false),
                    loginerrorcount = table.Column<int>(type: "INTEGER", nullable: false),
                    lastloginerrortime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    lastlogintime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    latestname = table.Column<string>(type: "TEXT", nullable: false),
                    firstname = table.Column<string>(type: "TEXT", nullable: false),
                    createdat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    creator = table.Column<Guid>(type: "TEXT", nullable: true),
                    updatedat = table.Column<DateTime>(type: "TEXT", nullable: true),
                    modifier = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "sessiongroups",
                columns: new[] { "id", "createdat", "creator", "isdefault", "modifier", "name", "sort", "updatedat" },
                values: new object[] { new Guid("6205d3b7-ef0c-4734-9dc7-38ad18b7e964"), new DateTime(2024, 11, 11, 0, 40, 10, 885, DateTimeKind.Local).AddTicks(8662), new Guid("745c2272-c49e-439c-b80b-926d21fc50c4"), false, null, "Default", 0, null });

            migrationBuilder.InsertData(
                table: "sessions",
                columns: new[] { "id", "avatar", "config", "createdat", "creator", "description", "groupid", "historylimit", "model", "modifier", "pinned", "plugins", "presencepenalty", "provider", "systemrole", "tags", "temperature", "title", "topp", "type", "updatedat" },
                values: new object[] { 1L, "https://registry.npmmirror.com/@lobehub/fluent-emoji-3d/1.1.0/files/assets/1f92f.webp", "{\"$id\":\"1\"}", new DateTime(2024, 11, 11, 0, 40, 10, 885, DateTimeKind.Local).AddTicks(8691), new Guid("745c2272-c49e-439c-b80b-926d21fc50c4"), "Default", new Guid("6205d3b7-ef0c-4734-9dc7-38ad18b7e964"), -1, "gpt-4o", null, false, "[]", 0f, "openai", "", "[]", 1f, "Default", 1f, null, null });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar", "createdat", "creator", "email", "firstname", "lastloginerrortime", "lastlogintime", "latestname", "loginerrorcount", "modifier", "password", "passwordsalt", "state", "updatedat", "username" },
                values: new object[] { new Guid("745c2272-c49e-439c-b80b-926d21fc50c4"), "https://chat-preview.lobehub.com/icons/icon-192x192.png", new DateTime(2024, 11, 11, 0, 40, 10, 885, DateTimeKind.Local).AddTicks(7944), null, "239573049@qq.com", "Admin", null, null, "Admin", 0, null, "81c75bd7a12542812272bd2b6d3096f1962d66b10588e910bd2bf80a45ff30ec", "e9868438e42647a88ecb528d5da25faa", (byte)1, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_filestorages_createdat",
                table: "filestorages",
                column: "createdat");

            migrationBuilder.CreateIndex(
                name: "IX_filestorages_filetype",
                table: "filestorages",
                column: "filetype");

            migrationBuilder.CreateIndex(
                name: "IX_filestorages_name",
                table: "filestorages",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_messages_createdat",
                table: "messages",
                column: "createdat");

            migrationBuilder.CreateIndex(
                name: "IX_messages_role",
                table: "messages",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "IX_messages_sessionid",
                table: "messages",
                column: "sessionid");

            migrationBuilder.CreateIndex(
                name: "IX_plugins_functionname",
                table: "plugins",
                column: "functionname");

            migrationBuilder.CreateIndex(
                name: "IX_plugins_type",
                table: "plugins",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_plugins_version",
                table: "plugins",
                column: "version");

            migrationBuilder.CreateIndex(
                name: "IX_sessiongroups_createdat",
                table: "sessiongroups",
                column: "createdat");

            migrationBuilder.CreateIndex(
                name: "IX_sessiongroups_name",
                table: "sessiongroups",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_createdat",
                table: "sessions",
                column: "createdat");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_groupid",
                table: "sessions",
                column: "groupid");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_title",
                table: "sessions",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_useroauthextensions_provider",
                table: "useroauthextensions",
                column: "provider");

            migrationBuilder.CreateIndex(
                name: "IX_useroauthextensions_providerkey",
                table: "useroauthextensions",
                column: "providerkey");

            migrationBuilder.CreateIndex(
                name: "IX_useroauthextensions_userid",
                table: "useroauthextensions",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_state",
                table: "users",
                column: "state");

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "filestorages");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "plugins");

            migrationBuilder.DropTable(
                name: "sessiongroups");

            migrationBuilder.DropTable(
                name: "sessions");

            migrationBuilder.DropTable(
                name: "useroauthextensions");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Persistance.Migrations
{
    public partial class ChangeReservationLimitName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "52e9e7b3-49d6-4700-b90b-df116d8d3958", "a7222662-0d1c-44c0-9af4-336c3f7bfcc7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e1aef13-c371-45c5-8105-3e3f74cbabea", "d9b38f46-5b65-43c6-8d2e-58ee3d48d3ab" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52e9e7b3-49d6-4700-b90b-df116d8d3958");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e1aef13-c371-45c5-8105-3e3f74cbabea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7222662-0d1c-44c0-9af4-336c3f7bfcc7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9b38f46-5b65-43c6-8d2e-58ee3d48d3ab");

            migrationBuilder.CreateTable(
                name: "EventTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationTimeLimit = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    TicketStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTickets_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7699734e-ecf5-4b44-adae-8af621f957dc", "99b4ad1d-9fb9-4cc8-a874-6a2615dcdbf6", "Admin", "ADMIN" },
                    { "b78249bf-a7c6-434d-bf35-665d4606498e", "f57f6751-3537-4b5d-8f5c-0eb4a8ee9fb0", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2224e060-4567-4790-9d8e-57a72b2df769", 0, "fcd7ad46-b024-4541-8d1e-ddc127847a09", "admin@gmail.com", true, "Admin", "Adminashvili", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "724A21F4CE30D9E0EFF3F36434DBCD9F3FEA1CC7A2A992F11746D1426E4BC09C647CAEFB918196786EFE8F842BE255CF28589153D5E2402C3B4DBE979297C09F", null, false, "728a7218-983f-4f55-8d0b-3497a4eb3f19", false, "admin@gmail.com" },
                    { "a259a56d-1538-46ba-bbea-6db73a52497c", 0, "e03b729a-22f5-424f-b6df-49d71a2c3f26", "user@gmail.com", true, "User", "Userashvili", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "FFF0B8AA9F72C048FDD846339B9971FC5601EF26D5E422543E195E5B5BF0DC4E224820FCDBD39CFCA2FE76B86D62B269B15011BF5846F2EFE4327097FB9F0B8C", null, false, "e3c7fec4-7c4c-420f-a801-c4ffaf792b1a", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7699734e-ecf5-4b44-adae-8af621f957dc", "2224e060-4567-4790-9d8e-57a72b2df769" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b78249bf-a7c6-434d-bf35-665d4606498e", "a259a56d-1538-46ba-bbea-6db73a52497c" });

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_EventId",
                table: "EventTickets",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTickets");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7699734e-ecf5-4b44-adae-8af621f957dc", "2224e060-4567-4790-9d8e-57a72b2df769" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b78249bf-a7c6-434d-bf35-665d4606498e", "a259a56d-1538-46ba-bbea-6db73a52497c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7699734e-ecf5-4b44-adae-8af621f957dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b78249bf-a7c6-434d-bf35-665d4606498e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2224e060-4567-4790-9d8e-57a72b2df769");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a259a56d-1538-46ba-bbea-6db73a52497c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "52e9e7b3-49d6-4700-b90b-df116d8d3958", "7924c5a1-15f7-4f5f-b78d-6930602f1b69", "Admin", "ADMIN" },
                    { "8e1aef13-c371-45c5-8105-3e3f74cbabea", "0165057c-f785-4d53-a7ab-540b23b72c69", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a7222662-0d1c-44c0-9af4-336c3f7bfcc7", 0, "8c206bb2-6ce4-45cd-94f4-21971488344d", "admin@gmail.com", true, "Admin", "Adminashvili", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "724A21F4CE30D9E0EFF3F36434DBCD9F3FEA1CC7A2A992F11746D1426E4BC09C647CAEFB918196786EFE8F842BE255CF28589153D5E2402C3B4DBE979297C09F", null, false, "5b85365c-dbd9-415a-b6ac-ae33c5214800", false, "admin@gmail.com" },
                    { "d9b38f46-5b65-43c6-8d2e-58ee3d48d3ab", 0, "aaf3cfc9-533f-422f-9670-d1a13add605f", "user@gmail.com", true, "User", "Userashvili", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "FFF0B8AA9F72C048FDD846339B9971FC5601EF26D5E422543E195E5B5BF0DC4E224820FCDBD39CFCA2FE76B86D62B269B15011BF5846F2EFE4327097FB9F0B8C", null, false, "a3844ecb-2609-4a28-a819-561010d6fca7", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "52e9e7b3-49d6-4700-b90b-df116d8d3958", "a7222662-0d1c-44c0-9af4-336c3f7bfcc7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e1aef13-c371-45c5-8105-3e3f74cbabea", "d9b38f46-5b65-43c6-8d2e-58ee3d48d3ab" });
        }
    }
}

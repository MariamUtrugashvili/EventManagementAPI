using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Persistance.Migrations
{
    public partial class AddNewEventTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTickets_Event_EventId",
                table: "EventTickets");

            migrationBuilder.DropIndex(
                name: "IX_EventTickets_EventId",
                table: "EventTickets");

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

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventTickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e49c72a-8961-4297-a6e4-7215c9ed49ea", "b8a8825c-51d6-4329-aa4d-6bedc4b26e65", "Admin", "ADMIN" },
                    { "ea732818-1c1a-4931-a149-753fa3f52aad", "9e95ed99-c1c0-4bac-862e-29b004c77490", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "790402bc-5f6d-490d-ba4e-3a1c7e69e98f", 0, "3ca6c073-7287-4ee6-89a3-b4bdc0de6120", "admin@gmail.com", true, "Admin", "Adminashvili", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "724A21F4CE30D9E0EFF3F36434DBCD9F3FEA1CC7A2A992F11746D1426E4BC09C647CAEFB918196786EFE8F842BE255CF28589153D5E2402C3B4DBE979297C09F", null, false, "0d68e86b-b278-4253-828a-47174d136e23", false, "admin@gmail.com" },
                    { "791f184c-8c1c-44e9-8556-6c5654c51e4a", 0, "8b09a645-7f65-4a65-8e43-8756d43a7acf", "user@gmail.com", true, "User", "Userashvili", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "FFF0B8AA9F72C048FDD846339B9971FC5601EF26D5E422543E195E5B5BF0DC4E224820FCDBD39CFCA2FE76B86D62B269B15011BF5846F2EFE4327097FB9F0B8C", null, false, "375036a5-a9dc-4ea5-bc72-82b66b74a321", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2e49c72a-8961-4297-a6e4-7215c9ed49ea", "790402bc-5f6d-490d-ba4e-3a1c7e69e98f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ea732818-1c1a-4931-a149-753fa3f52aad", "791f184c-8c1c-44e9-8556-6c5654c51e4a" });

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_EventItemId",
                table: "EventTickets",
                column: "EventItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTickets_Event_EventItemId",
                table: "EventTickets",
                column: "EventItemId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTickets_Event_EventItemId",
                table: "EventTickets");

            migrationBuilder.DropIndex(
                name: "IX_EventTickets_EventItemId",
                table: "EventTickets");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2e49c72a-8961-4297-a6e4-7215c9ed49ea", "790402bc-5f6d-490d-ba4e-3a1c7e69e98f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ea732818-1c1a-4931-a149-753fa3f52aad", "791f184c-8c1c-44e9-8556-6c5654c51e4a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e49c72a-8961-4297-a6e4-7215c9ed49ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea732818-1c1a-4931-a149-753fa3f52aad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "790402bc-5f6d-490d-ba4e-3a1c7e69e98f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "791f184c-8c1c-44e9-8556-6c5654c51e4a");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventTickets",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_EventTickets_Event_EventId",
                table: "EventTickets",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Persistance.Migrations
{
    public partial class AddAdminUserToAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "61294d62-80e3-4c3b-934a-b7f280cbb49b", "1a12419b-36c5-4224-aee0-40a5ad5ad1fc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ac623c92-6c33-4afe-9458-150d2aa36dab", "eff53e10-73ad-4f60-89f1-617f3b4f6840" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61294d62-80e3-4c3b-934a-b7f280cbb49b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac623c92-6c33-4afe-9458-150d2aa36dab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a12419b-36c5-4224-aee0-40a5ad5ad1fc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eff53e10-73ad-4f60-89f1-617f3b4f6840");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61294d62-80e3-4c3b-934a-b7f280cbb49b", "8ce5634d-b0f2-4705-94c0-99842641989e", "Admin", "ADMIN" },
                    { "ac623c92-6c33-4afe-9458-150d2aa36dab", "fb25366c-ba1e-4b80-a160-74d3835ba02e", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a12419b-36c5-4224-aee0-40a5ad5ad1fc", 0, "5761dd47-7b37-4327-a739-bd0f3d622fcf", "admin@gmail.com", true, "Admin", "Adminashvili", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "724A21F4CE30D9E0EFF3F36434DBCD9F3FEA1CC7A2A992F11746D1426E4BC09C647CAEFB918196786EFE8F842BE255CF28589153D5E2402C3B4DBE979297C09F", null, false, "6c962b8f-37e7-4471-9cb7-bbbf9b0f706e", false, "admin@gmail.com" },
                    { "eff53e10-73ad-4f60-89f1-617f3b4f6840", 0, "f92625f0-2e53-4426-8c69-33d7ffd3a7b2", "user@gmail.com", true, "User", "Userashvili", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "FFF0B8AA9F72C048FDD846339B9971FC5601EF26D5E422543E195E5B5BF0DC4E224820FCDBD39CFCA2FE76B86D62B269B15011BF5846F2EFE4327097FB9F0B8C", null, false, "12843dc9-e61b-4b43-8ae8-3fb63a61cab1", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "61294d62-80e3-4c3b-934a-b7f280cbb49b", "1a12419b-36c5-4224-aee0-40a5ad5ad1fc" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ac623c92-6c33-4afe-9458-150d2aa36dab", "eff53e10-73ad-4f60-89f1-617f3b4f6840" });
        }
    }
}

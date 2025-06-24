using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Persistance.Migrations
{
    public partial class SeedDefaultUserAndAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5300f449-2e60-4d41-ba2d-6cb87cf0b2d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "691bc685-2897-4645-96ae-19f418b53188");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "909a3a4b-785d-4ed1-a32a-6807cb282f8a", "767c0f79-0db6-49a3-b5ed-18a1070cfb97", "User", "USER" },
                    { "ebdbc42e-a346-4f6d-9a60-e0110362724e", "6c8b6f09-bcc0-41b9-b86d-f6089cd84f5c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "adbd48a7-bc7c-4442-955b-52608df24ed2", 0, "512d3bfa-e8c0-459f-85fb-c3f872f806c5", "admin@gmail.com", true, "Admin", "Adminashvili", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "724A21F4CE30D9E0EFF3F36434DBCD9F3FEA1CC7A2A992F11746D1426E4BC09C647CAEFB918196786EFE8F842BE255CF28589153D5E2402C3B4DBE979297C09F", null, false, "fbfca27f-3bac-4ea7-9053-8c677d776508", false, "admin@gmail.com" },
                    { "e82289ba-a3cc-4ce7-b40a-226aabeb5837", 0, "c6106d6f-4054-4cf0-9577-5872e53bc543", "user@gmail.com", true, "User", "Userashvili", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "FFF0B8AA9F72C048FDD846339B9971FC5601EF26D5E422543E195E5B5BF0DC4E224820FCDBD39CFCA2FE76B86D62B269B15011BF5846F2EFE4327097FB9F0B8C", null, false, "886fcbb9-65f1-4003-92e7-ab376c62e7b5", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "909a3a4b-785d-4ed1-a32a-6807cb282f8a", "e82289ba-a3cc-4ce7-b40a-226aabeb5837" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebdbc42e-a346-4f6d-9a60-e0110362724e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "909a3a4b-785d-4ed1-a32a-6807cb282f8a", "e82289ba-a3cc-4ce7-b40a-226aabeb5837" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adbd48a7-bc7c-4442-955b-52608df24ed2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "909a3a4b-785d-4ed1-a32a-6807cb282f8a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e82289ba-a3cc-4ce7-b40a-226aabeb5837");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5300f449-2e60-4d41-ba2d-6cb87cf0b2d2", "586bbd53-0362-42bc-b130-401c20b37275", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "691bc685-2897-4645-96ae-19f418b53188", "b49f40c5-c9c0-4fe8-a9b2-2e6cfa8b306d", "Admin", "ADMIN" });
        }
    }
}

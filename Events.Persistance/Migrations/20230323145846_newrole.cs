using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Persistance.Migrations
{
    public partial class Newrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1826c09c-a38d-4d19-a6f9-10724b0e8d79", "f042e8e4-abbc-4708-b800-7e15183d9582", "Admin", "ADMIN" },
                    { "32b4f3bd-dfb8-4a16-b646-199afdd2b680", "a28ff2d5-20a3-4343-b81c-d1b3febc6b5b", "Moderator", "MODERATOR" },
                    { "ad6c8ac9-a3e0-41cd-a8c5-1444013c430a", "176728cd-7fc7-4102-a2f2-4a9c69304ac1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "326ecedd-6636-4136-9d6e-e86ac4f63653", 0, "a35b8dd8-5d9f-4022-b463-5b224b536a43", "Moderator@gmail.com", true, "Moderator", "Moderatoridze", false, null, "MODERATOR@GMAIL.COM", "MODERATOR@GMAIL.COM", "BFFA92BA5E1D542981843CAFEEAAB2FDC44067BBD3702B98178E3C48DE998A36297A382E2D53D71D018DA1DCC7614E8C355C90E79D4B1B074185B749034E1784", null, false, "850898e3-0e28-4423-bd54-f8327e29d723", false, "Moderator@gmail.com" },
                    { "4c219ee7-cd19-4f50-96bf-a6d5e05be24a", 0, "82df03e4-a36f-477a-b25d-d16af4f1fbb8", "user@gmail.com", true, "User", "Userashvili", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "FFF0B8AA9F72C048FDD846339B9971FC5601EF26D5E422543E195E5B5BF0DC4E224820FCDBD39CFCA2FE76B86D62B269B15011BF5846F2EFE4327097FB9F0B8C", null, false, "c6a0b675-73f1-4862-8846-77d55850ae65", false, "user@gmail.com" },
                    { "8aa08681-b670-46a3-b5b9-5e68815a9337", 0, "3f36e37a-de7b-4fe6-9fd3-8498f7d4d12d", "admin@gmail.com", true, "Admin", "Adminashvili", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "724A21F4CE30D9E0EFF3F36434DBCD9F3FEA1CC7A2A992F11746D1426E4BC09C647CAEFB918196786EFE8F842BE255CF28589153D5E2402C3B4DBE979297C09F", null, false, "55539bb0-2a5a-42df-bc13-5425d7041996", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "32b4f3bd-dfb8-4a16-b646-199afdd2b680", "326ecedd-6636-4136-9d6e-e86ac4f63653" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad6c8ac9-a3e0-41cd-a8c5-1444013c430a", "4c219ee7-cd19-4f50-96bf-a6d5e05be24a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1826c09c-a38d-4d19-a6f9-10724b0e8d79", "8aa08681-b670-46a3-b5b9-5e68815a9337" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "32b4f3bd-dfb8-4a16-b646-199afdd2b680", "326ecedd-6636-4136-9d6e-e86ac4f63653" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad6c8ac9-a3e0-41cd-a8c5-1444013c430a", "4c219ee7-cd19-4f50-96bf-a6d5e05be24a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1826c09c-a38d-4d19-a6f9-10724b0e8d79", "8aa08681-b670-46a3-b5b9-5e68815a9337" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1826c09c-a38d-4d19-a6f9-10724b0e8d79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32b4f3bd-dfb8-4a16-b646-199afdd2b680");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad6c8ac9-a3e0-41cd-a8c5-1444013c430a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "326ecedd-6636-4136-9d6e-e86ac4f63653");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4c219ee7-cd19-4f50-96bf-a6d5e05be24a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aa08681-b670-46a3-b5b9-5e68815a9337");

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
        }
    }
}

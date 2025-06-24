using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Persistance.Migrations
{
    public partial class RemoveGuestRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f7df644-202b-432a-8074-64d49b39d7b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "563bedd2-3cdc-4dfe-9be3-81582f953195");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5761a0c2-b1cd-4bdf-bb46-0414de9e654e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c312d83-789f-4fbf-97f0-858344245787", "264ced6f-d4da-420f-86b4-0fb41ae18299", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edaadb5d-d4c5-4309-8fb9-42433b90203b", "c6c1a75c-db68-49af-b104-5fb4fabe8536", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c312d83-789f-4fbf-97f0-858344245787");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edaadb5d-d4c5-4309-8fb9-42433b90203b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f7df644-202b-432a-8074-64d49b39d7b5", "0a520fce-5ec0-4e36-8ce7-27e49438daac", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "563bedd2-3cdc-4dfe-9be3-81582f953195", "e5c10989-50d5-4043-87e9-a25653d9000a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5761a0c2-b1cd-4bdf-bb46-0414de9e654e", "b51ac9ab-83cf-433a-b785-ad4a004108ae", "Guest", "GUEST" });
        }
    }
}

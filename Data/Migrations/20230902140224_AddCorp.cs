using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddCorp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Client",
                column: "ConcurrencyStamp",
                value: "ba624409-16af-42c8-840d-a84e7161fafc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Driver",
                column: "ConcurrencyStamp",
                value: "29e3e874-11b8-44c4-85b0-a0e4b235f679");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Full",
                column: "ConcurrencyStamp",
                value: "d8ea031f-a6f2-4240-aed2-26f772505056");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Partner",
                column: "ConcurrencyStamp",
                value: "4dbb307e-3f11-4d67-b78a-e3e1b5aebb14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "Corporation", "8cfffe1b-d422-482c-bf17-108f26b714ca", "Roles", "Corporation", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Corporation");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Client",
                column: "ConcurrencyStamp",
                value: "fdd18615-6949-4d8d-a11f-e03275a6f073");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Driver",
                column: "ConcurrencyStamp",
                value: "aaf93a25-89d1-4f7c-9758-4da8c2d8a62e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Full",
                column: "ConcurrencyStamp",
                value: "224448b7-93a2-4709-a2e6-f89127f33b87");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Partner",
                column: "ConcurrencyStamp",
                value: "afac6b45-d599-4cb8-b3b1-ea179dcb8c67");
        }
    }
}

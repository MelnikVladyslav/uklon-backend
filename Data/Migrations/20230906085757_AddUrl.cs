using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Client",
                column: "ConcurrencyStamp",
                value: "624781ba-1b3d-4edc-be06-207a4e0a8d89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Corporation",
                column: "ConcurrencyStamp",
                value: "5edd6043-feeb-415a-855b-11d3e65870a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Driver",
                column: "ConcurrencyStamp",
                value: "ced7681f-cb97-42ae-bfe2-f0f9b514a124");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Full",
                column: "ConcurrencyStamp",
                value: "46aac44c-c17f-42bd-80f5-122966df9bb1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Partner",
                column: "ConcurrencyStamp",
                value: "70fc2560-0cd7-4c4e-9529-bcc0870dbced");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Client",
                column: "ConcurrencyStamp",
                value: "ba624409-16af-42c8-840d-a84e7161fafc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Corporation",
                column: "ConcurrencyStamp",
                value: "8cfffe1b-d422-482c-bf17-108f26b714ca");

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
        }
    }
}

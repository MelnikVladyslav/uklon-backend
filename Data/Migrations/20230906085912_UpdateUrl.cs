using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdateUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "6a000ab2-2640-480e-8ede-93469820fbb7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Corporation",
                column: "ConcurrencyStamp",
                value: "924ee1c8-206c-45cd-aaf5-6b20324d868e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Driver",
                column: "ConcurrencyStamp",
                value: "5da52cd0-a6dc-4738-ba9a-f80732f3aaf9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Full",
                column: "ConcurrencyStamp",
                value: "6ee510de-417f-49a0-b229-eb165ac3002b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Partner",
                column: "ConcurrencyStamp",
                value: "47c4e181-df96-449e-9845-12b688d2c0d8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdateSelAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SelAdresses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Client",
                column: "ConcurrencyStamp",
                value: "5768a46d-43a6-44ca-9838-a01712dc15d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Corporation",
                column: "ConcurrencyStamp",
                value: "9bc9fc87-59d0-40c5-ad6d-340b3f78ae37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Driver",
                column: "ConcurrencyStamp",
                value: "874d82c0-cc84-4ddd-a6fc-afb967d88f58");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Full",
                column: "ConcurrencyStamp",
                value: "27cce6b8-8c55-490c-90c8-6a9e7c022cbe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Partner",
                column: "ConcurrencyStamp",
                value: "35bebc4d-fc55-4d6e-930e-460c633acba5");

            migrationBuilder.CreateIndex(
                name: "IX_SelAdresses_UserId",
                table: "SelAdresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelAdresses_AspNetUsers_UserId",
                table: "SelAdresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelAdresses_AspNetUsers_UserId",
                table: "SelAdresses");

            migrationBuilder.DropIndex(
                name: "IX_SelAdresses_UserId",
                table: "SelAdresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SelAdresses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Client",
                column: "ConcurrencyStamp",
                value: "6fbc7ba0-7653-4224-b186-e1047751af63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Corporation",
                column: "ConcurrencyStamp",
                value: "bc558a40-3f96-4fa5-bd82-984b3e813a95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Driver",
                column: "ConcurrencyStamp",
                value: "6b9fefe8-f50a-494e-b001-7ee178603636");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Full",
                column: "ConcurrencyStamp",
                value: "fa3035ed-f3d7-4c7f-9ec0-cd2e02e7cb47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Partner",
                column: "ConcurrencyStamp",
                value: "584a3e0d-ee4c-4483-8097-4e7178127b8c");
        }
    }
}

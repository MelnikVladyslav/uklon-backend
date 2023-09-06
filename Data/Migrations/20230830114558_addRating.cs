using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    public partial class addRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Client",
                column: "ConcurrencyStamp",
                value: "e8e0fb93-dcfa-4573-a4e9-4ca5d4fba9cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Driver",
                column: "ConcurrencyStamp",
                value: "0da9b3bd-46f5-4f77-8ebc-d6b90c848cb0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Full",
                column: "ConcurrencyStamp",
                value: "bd423adf-a461-424e-9a8a-203d5b9fb0d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Partner",
                column: "ConcurrencyStamp",
                value: "806dce42-4ab7-4013-985f-314347d67e44");
        }
    }
}

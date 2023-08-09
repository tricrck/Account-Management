using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBankingApp.Migrations
{
    public partial class B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Customers",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("7bbbdb09-9f22-4244-ab0b-1edf7918ec69"),
                columns: new[] { "RoleId", "Status" },
                values: new object[] { 1, true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("e7c2dd45-480c-4400-a065-5f828ba588f3"),
                columns: new[] { "RoleId", "Status" },
                values: new object[] { 3, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 2);
        }
    }
}

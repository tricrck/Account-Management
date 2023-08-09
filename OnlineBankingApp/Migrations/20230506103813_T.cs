using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBankingApp.Migrations
{
    public partial class T : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 1, "Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 2, "Customer" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 3, "Teller" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "ConfirmPassword", "CustomerName", "Password", "Phone", "PostCode", "RoleId", "State", "Tfn" },
                values: new object[] { new Guid("7bbbdb09-9f22-4244-ab0b-1edf7918ec69"), "Casa De Shenandoah", "Vegas", "Admin", "Manager Banks", "Admin", "123-123-1234", "1234", 1, "nsw", "123456789" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "ConfirmPassword", "CustomerName", "Password", "Phone", "PostCode", "RoleId", "State", "Tfn" },
                values: new object[] { new Guid("e7c2dd45-480c-4400-a065-5f828ba588f3"), "Casa De Shenandoah", "Vegas", "Teller", "Teller Banks", "Admin", "123-123-1234", "1234", 3, "nsw", "123456789" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RoleId",
                table: "Customers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Roles_RoleId",
                table: "Customers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Roles_RoleId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RoleId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("7bbbdb09-9f22-4244-ab0b-1edf7918ec69"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: new Guid("e7c2dd45-480c-4400-a065-5f828ba588f3"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Customers");
        }
    }
}

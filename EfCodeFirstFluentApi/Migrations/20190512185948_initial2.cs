using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCodeFirstFluentApi.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Soyad",
                table: "Customers",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2019, 5, 12, 21, 59, 47, 851, DateTimeKind.Local).AddTicks(9749));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Customers",
                newName: "Soyad");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "Ad");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2019, 5, 12, 21, 34, 19, 864, DateTimeKind.Local).AddTicks(596));
        }
    }
}

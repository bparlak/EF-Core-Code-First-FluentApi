using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCodeFirstFluentApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    Ad = table.Column<string>(maxLength: 20, nullable: false),
                    Soyad = table.Column<string>(maxLength: 20, nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    City = table.Column<string>(maxLength: 15, nullable: true),
                    Country = table.Column<string>(maxLength: 15, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<string>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Age", "City", "Country", "Email", "Ad", "Soyad", "UserName" },
                values: new object[,]
                {
                    { "a1", 29, "Ankara", "Turkey", "info@burakparlak.com", "Burak", "Parlak", "bparlak" },
                    { "a2", 29, "Ankara", "Turkey", "info@burakparlak.com", "Burak", "Parlak", "bparlak" },
                    { "a3", 29, "Ankara", "Turkey", "info@burakparlak.com", "Burak", "Parlak", "bparlak" },
                    { "a4", 29, "Ankara", "Turkey", "info@burakparlak.com", "Burak", "Parlak", "bparlak" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate" },
                values: new object[] { 1, "a1", new DateTime(2019, 5, 12, 21, 34, 19, 864, DateTimeKind.Local).AddTicks(596) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

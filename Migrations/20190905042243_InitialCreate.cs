using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: false),
                    Mobile = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    customerID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_customerID",
                        column: x => x.customerID,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerID", "Email", "Mobile", "Name" },
                values: new object[] { 1L, "user@domain.com", "0123456789", "Firstname Lastname" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerID", "Email", "Mobile", "Name" },
                values: new object[] { 2L, "user2@domain.com", "111111111", "Firstname2 Lastname2" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerID", "Email", "Mobile", "Name" },
                values: new object[] { 3L, "user3@domain.com", "222222222", "Firstname3 Lastname3" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "Amount", "Currency", "Date", "Status", "customerID" },
                values: new object[] { 1L, 1234.56m, "USD", new DateTime(2018, 2, 28, 21, 34, 0, 0, DateTimeKind.Unspecified), 0, 1L });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "Amount", "Currency", "Date", "Status", "customerID" },
                values: new object[] { 2L, 2234.56m, "THB", new DateTime(2018, 3, 28, 21, 34, 0, 0, DateTimeKind.Unspecified), 1, 1L });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "Amount", "Currency", "Date", "Status", "customerID" },
                values: new object[] { 3L, 12234.56m, "SGD", new DateTime(2018, 4, 28, 21, 34, 0, 0, DateTimeKind.Unspecified), 0, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_customerID",
                table: "Transactions",
                column: "customerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

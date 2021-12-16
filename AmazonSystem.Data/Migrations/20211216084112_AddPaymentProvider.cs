using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonSystem.Data.Migrations
{
    public partial class AddPaymentProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustommerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashPayments_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashPayments_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustommerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardExpires = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvvCode = table.Column<int>(type: "int", nullable: false),
                    NameOfCard = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardPayments_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaypalPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustommerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaypalPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaypalPayments_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashPayments_AddressId",
                table: "CashPayments",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPayments_CustomerId",
                table: "CashPayments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardPayments_CustomerId",
                table: "CreditCardPayments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaypalPayments_CustomerId",
                table: "PaypalPayments",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashPayments");

            migrationBuilder.DropTable(
                name: "CreditCardPayments");

            migrationBuilder.DropTable(
                name: "PaypalPayments");
        }
    }
}

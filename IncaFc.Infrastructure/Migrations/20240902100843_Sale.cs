using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncaFc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Sale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    SaleDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IGV = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.SaleDetailId);
                    table.ForeignKey(
                        name: "FK_SalesDetails_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetailsProductIds",
                columns: table => new
                {
                    SaleDetailProducId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetailsProductIds", x => x.SaleDetailProducId);
                    table.ForeignKey(
                        name: "FK_SalesDetailsProductIds_SalesDetails_SaleDetailId",
                        column: x => x.SaleDetailId,
                        principalTable: "SalesDetails",
                        principalColumn: "SaleDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SaleId",
                table: "SalesDetails",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailsProductIds_SaleDetailId",
                table: "SalesDetailsProductIds",
                column: "SaleDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetailsProductIds");

            migrationBuilder.DropTable(
                name: "SalesDetails");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncaFc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SaleModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "SalesDetails",
                newName: "TotalNeto");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBruto",
                table: "SalesDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBruto",
                table: "SalesDetails");

            migrationBuilder.RenameColumn(
                name: "TotalNeto",
                table: "SalesDetails",
                newName: "Total");
        }
    }
}

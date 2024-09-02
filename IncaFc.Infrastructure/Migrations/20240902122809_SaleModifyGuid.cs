using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncaFc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SaleModifyGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IGV",
                table: "SalesDetails",
                newName: "Igv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Igv",
                table: "SalesDetails",
                newName: "IGV");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncaFc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SaleModifyGuid2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesDetailsProductIds",
                table: "SalesDetailsProductIds");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetailsProductIds_SaleDetailId",
                table: "SalesDetailsProductIds");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SalesDetailsProductIds",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesDetailsProductIds",
                table: "SalesDetailsProductIds",
                columns: new[] { "SaleDetailId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesDetailsProductIds",
                table: "SalesDetailsProductIds");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SalesDetailsProductIds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesDetailsProductIds",
                table: "SalesDetailsProductIds",
                column: "SaleDetailProducId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailsProductIds_SaleDetailId",
                table: "SalesDetailsProductIds",
                column: "SaleDetailId");
        }
    }
}

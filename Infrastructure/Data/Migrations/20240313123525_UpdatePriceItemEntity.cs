using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriceItemEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceItems",
                table: "PriceItems");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PriceItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceItems",
                table: "PriceItems",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceItems",
                table: "PriceItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PriceItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceItems",
                table: "PriceItems",
                columns: new[] { "Vendor", "Number" });
        }
    }
}

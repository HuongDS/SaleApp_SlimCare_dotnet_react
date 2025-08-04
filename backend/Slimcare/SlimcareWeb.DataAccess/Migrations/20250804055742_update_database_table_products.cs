using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlimcareWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update_database_table_products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "ID");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlimcareWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update_table_refresh_token_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReplacedAt",
                table: "RefreshTokens",
                newName: "RevokeAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RevokeAt",
                table: "RefreshTokens",
                newName: "ReplacedAt");
        }
    }
}

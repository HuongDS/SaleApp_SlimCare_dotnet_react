using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlimcareWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnsaltingtotableuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salting",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Delete_At",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salting",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Delete_At",
                table: "Reviews");
        }
    }
}

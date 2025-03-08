using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileSource.Migrations
{
    /// <inheritdoc />
    public partial class LicenseTabelTodayLimitColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TodayLimit",
                table: "License",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TodayLimit",
                table: "License");
        }
    }
}

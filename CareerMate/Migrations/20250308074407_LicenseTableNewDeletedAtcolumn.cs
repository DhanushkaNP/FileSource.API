using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileSource.Migrations
{
    /// <inheritdoc />
    public partial class LicenseTableNewDeletedAtcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "License",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "License");
        }
    }
}

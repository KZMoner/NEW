using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace New.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "rotien",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Date",
                table: "rotien",
                type: "integer",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}

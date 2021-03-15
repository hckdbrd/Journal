using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Journal.Migrations
{
    public partial class _1015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearOfEntry",
                table: "Students",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "YearOfEntry",
                table: "Students",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "datetime2");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Journal.Migrations
{
    public partial class _2004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Specializations_SpecializationId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Specializations_SpecializationId",
                table: "Students",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Specializations_SpecializationId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Specializations_SpecializationId",
                table: "Students",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

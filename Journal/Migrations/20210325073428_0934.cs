using Microsoft.EntityFrameworkCore.Migrations;

namespace Journal.Migrations
{
    public partial class _0934 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherJournal_Journals_JournalId",
                table: "TeacherJournal");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherJournal_Teachers_TeacherId",
                table: "TeacherJournal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherJournal",
                table: "TeacherJournal");

            migrationBuilder.RenameTable(
                name: "TeacherJournal",
                newName: "TeachersJournals");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherJournal_TeacherId",
                table: "TeachersJournals",
                newName: "IX_TeachersJournals_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeachersJournals",
                table: "TeachersJournals",
                columns: new[] { "JournalId", "TeacherId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersJournals_Journals_JournalId",
                table: "TeachersJournals",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersJournals_Teachers_TeacherId",
                table: "TeachersJournals",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeachersJournals_Journals_JournalId",
                table: "TeachersJournals");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersJournals_Teachers_TeacherId",
                table: "TeachersJournals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeachersJournals",
                table: "TeachersJournals");

            migrationBuilder.RenameTable(
                name: "TeachersJournals",
                newName: "TeacherJournal");

            migrationBuilder.RenameIndex(
                name: "IX_TeachersJournals_TeacherId",
                table: "TeacherJournal",
                newName: "IX_TeacherJournal_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherJournal",
                table: "TeacherJournal",
                columns: new[] { "JournalId", "TeacherId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherJournal_Journals_JournalId",
                table: "TeacherJournal",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherJournal_Teachers_TeacherId",
                table: "TeacherJournal",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

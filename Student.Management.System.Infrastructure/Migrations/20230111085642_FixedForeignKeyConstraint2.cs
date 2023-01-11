using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Management.System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedForeignKeyConstraint2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subjects_FavouriteSubjectSubjectId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FavouriteSubjectSubjectId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FavouriteSubjectSubjectId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Subjects",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SubjectId",
                table: "Students",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subjects_SubjectId",
                table: "Students",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subjects_SubjectId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SubjectId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subjects",
                newName: "SubjectId");

            migrationBuilder.AddColumn<int>(
                name: "FavouriteSubjectSubjectId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_FavouriteSubjectSubjectId",
                table: "Students",
                column: "FavouriteSubjectSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subjects_FavouriteSubjectSubjectId",
                table: "Students",
                column: "FavouriteSubjectSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId");
        }
    }
}

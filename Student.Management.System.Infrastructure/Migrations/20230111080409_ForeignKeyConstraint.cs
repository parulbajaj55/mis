using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Management.System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subjects_FavouriteSubjectId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FavouriteSubjectId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FavouriteSubjectId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subjects",
                newName: "SubjectId");

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
                principalColumn: "SubjectId",
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
                name: "SubjectId",
                table: "Subjects",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "FavouriteSubjectId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_FavouriteSubjectId",
                table: "Students",
                column: "FavouriteSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subjects_FavouriteSubjectId",
                table: "Students",
                column: "FavouriteSubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}

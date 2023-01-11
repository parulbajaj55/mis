using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Management.System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subjects",
                newName: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Subjects",
                newName: "Id");
        }
    }
}

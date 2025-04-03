using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Authorname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "authors",
                newName: "AuthorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "authors",
                newName: "Name");
        }
    }
}

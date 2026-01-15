using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCRUD.Migrations
{
    /// <inheritdoc />
    public partial class updateMarksheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarksheetPath",
                table: "academics");

            migrationBuilder.AddColumn<string>(
                name: "MarksheetPath",
                table: "documentinfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarksheetPath",
                table: "documentinfos");

            migrationBuilder.AddColumn<string>(
                name: "MarksheetPath",
                table: "academics",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCRUD.Migrations
{
    /// <inheritdoc />
    public partial class allIMageUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photoUrl",
                table: "students");

            migrationBuilder.DropColumn(
                name: "CitizenshipCopyPath",
                table: "citizenshipInfos");

            migrationBuilder.AddColumn<string>(
                name: "CitizenshipCopyPath",
                table: "documentinfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "photoUrl",
                table: "documentinfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitizenshipCopyPath",
                table: "documentinfos");

            migrationBuilder.DropColumn(
                name: "photoUrl",
                table: "documentinfos");

            migrationBuilder.AddColumn<string>(
                name: "photoUrl",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CitizenshipCopyPath",
                table: "citizenshipInfos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

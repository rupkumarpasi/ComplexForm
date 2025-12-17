using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCRUD.Migrations
{
    /// <inheritdoc />
    public partial class cascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scholarships_financials_FinancialId",
                table: "scholarships");

            migrationBuilder.DropColumn(
                name: "FinancialStudentId",
                table: "scholarships");

            migrationBuilder.AlterColumn<int>(
                name: "FinancialId",
                table: "scholarships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarships_financials_FinancialId",
                table: "scholarships",
                column: "FinancialId",
                principalTable: "financials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scholarships_financials_FinancialId",
                table: "scholarships");

            migrationBuilder.AlterColumn<int>(
                name: "FinancialId",
                table: "scholarships",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FinancialStudentId",
                table: "scholarships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarships_financials_FinancialId",
                table: "scholarships",
                column: "FinancialId",
                principalTable: "financials",
                principalColumn: "Id");
        }
    }
}

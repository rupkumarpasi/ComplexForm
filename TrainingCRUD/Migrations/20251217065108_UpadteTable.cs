using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCRUD.Migrations
{
    /// <inheritdoc />
    public partial class UpadteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_students_StudentId",
                table: "enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_financials_scholarships_scholarshipId",
                table: "financials");

            migrationBuilder.DropForeignKey(
                name: "FK_scholarships_students_StudentId",
                table: "scholarships");

            migrationBuilder.DropIndex(
                name: "IX_scholarships_StudentId",
                table: "scholarships");

            migrationBuilder.DropIndex(
                name: "IX_financials_scholarshipId",
                table: "financials");

            migrationBuilder.DropIndex(
                name: "IX_enrollments_StudentId",
                table: "enrollments");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "scholarships");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "scholarships");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "scholarships");

            migrationBuilder.DropColumn(
                name: "scholarshipId",
                table: "financials");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "enrollments");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "enrollments",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "FinancialStudentId",
                table: "scholarships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinancialId",
                table: "scholarships",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_scholarships_FinancialId",
                table: "scholarships",
                column: "FinancialId");

            migrationBuilder.AddForeignKey(
                name: "FK_scholarships_financials_FinancialId",
                table: "scholarships",
                column: "FinancialId",
                principalTable: "financials",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scholarships_financials_FinancialId",
                table: "scholarships");

            migrationBuilder.DropIndex(
                name: "IX_scholarships_FinancialId",
                table: "scholarships");

            migrationBuilder.DropColumn(
                name: "FinancialId",
                table: "scholarships");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "enrollments",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "FinancialStudentId",
                table: "scholarships",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "scholarships",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "scholarships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "scholarships",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "scholarshipId",
                table: "financials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_scholarships_StudentId",
                table: "scholarships",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_financials_scholarshipId",
                table: "financials",
                column: "scholarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_StudentId",
                table: "enrollments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_students_StudentId",
                table: "enrollments",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_financials_scholarships_scholarshipId",
                table: "financials",
                column: "scholarshipId",
                principalTable: "scholarships",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_scholarships_students_StudentId",
                table: "scholarships",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

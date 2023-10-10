using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Invoice_DepartmentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DEPARTMENT_ID",
                table: "INVOICES",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_DEPARTMENT_ID",
                table: "INVOICES",
                column: "DEPARTMENT_ID");

            migrationBuilder.AddForeignKey(
                name: "DEPARTMENT_INVOICES_DEPARTMENTID",
                table: "INVOICES",
                column: "DEPARTMENT_ID",
                principalTable: "DEPARTMENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "DEPARTMENT_INVOICES_DEPARTMENTID",
                table: "INVOICES");

            migrationBuilder.DropIndex(
                name: "IX_INVOICES_DEPARTMENT_ID",
                table: "INVOICES");

            migrationBuilder.DropColumn(
                name: "DEPARTMENT_ID",
                table: "INVOICES");
        }
    }
}

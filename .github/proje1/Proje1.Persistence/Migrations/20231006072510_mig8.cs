using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICES_REQUESTFORM_RequestFormId1",
                table: "INVOICES");

            migrationBuilder.DropIndex(
                name: "IX_INVOICES_RequestFormId1",
                table: "INVOICES");

            migrationBuilder.DropColumn(
                name: "RequestFormId1",
                table: "INVOICES");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "INVOICES",
                newName: "TOTAL_PRİCE");

            migrationBuilder.AlterColumn<double>(
                name: "TOTAL_PRİCE",
                table: "INVOICES",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float")
                .Annotation("Relational:ColumnOrder", 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TOTAL_PRİCE",
                table: "INVOICES",
                newName: "TotalPrice");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "INVOICES",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float")
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<int>(
                name: "RequestFormId1",
                table: "INVOICES",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_RequestFormId1",
                table: "INVOICES",
                column: "RequestFormId1",
                unique: true,
                filter: "[RequestFormId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICES_REQUESTFORM_RequestFormId1",
                table: "INVOICES",
                column: "RequestFormId1",
                principalTable: "REQUESTFORM",
                principalColumn: "ID");
        }
    }
}

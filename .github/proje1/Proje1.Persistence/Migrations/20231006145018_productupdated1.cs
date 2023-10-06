using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class productupdated1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_DEPARTMENT_DepartmentId",
                table: "PRODUCTS");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "PRODUCTS",
                newName: "DEPARTMENT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCTS_DepartmentId",
                table: "PRODUCTS",
                newName: "IX_PRODUCTS_DEPARTMENT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_DEPARTMENT_DEPARTMENT_ID",
                table: "PRODUCTS",
                column: "DEPARTMENT_ID",
                principalTable: "DEPARTMENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_DEPARTMENT_DEPARTMENT_ID",
                table: "PRODUCTS");

            migrationBuilder.RenameColumn(
                name: "DEPARTMENT_ID",
                table: "PRODUCTS",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUCTS_DEPARTMENT_ID",
                table: "PRODUCTS",
                newName: "IX_PRODUCTS_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_DEPARTMENT_DepartmentId",
                table: "PRODUCTS",
                column: "DepartmentId",
                principalTable: "DEPARTMENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

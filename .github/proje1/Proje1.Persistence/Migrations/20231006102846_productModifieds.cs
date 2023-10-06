using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class productModifieds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "PRODUCTS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_DepartmentId",
                table: "PRODUCTS",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_DEPARTMENT_DepartmentId",
                table: "PRODUCTS",
                column: "DepartmentId",
                principalTable: "DEPARTMENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_DEPARTMENT_DepartmentId",
                table: "PRODUCTS");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCTS_DepartmentId",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "PRODUCTS");
        }
    }
}

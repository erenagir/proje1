using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deneme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICES_REQUESTFORM_REQUESTFROM_ID",
                table: "INVOICES");

            migrationBuilder.DropForeignKey(
                name: "FK_OFFERS_REQUESTFORM_REQUESTFORM_ID",
                table: "OFFERS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_DEPARTMENT_DEPARTMENT_ID",
                table: "PRODUCTS");

            migrationBuilder.DropForeignKey(
                name: "FK_REPORTS_DEPARTMENT_DEPARTMENT_ID",
                table: "REPORTS");

            migrationBuilder.DropForeignKey(
                name: "yeni",
                table: "REPORTS");

            migrationBuilder.DropForeignKey(
                name: "FK_REQUESTFORM_PERSONS_PERSON_ID",
                table: "REQUESTFORM");

            migrationBuilder.AddForeignKey(
                name: "REQUESTFORM_INVOICES_REQUESTFORMID",
                table: "INVOICES",
                column: "REQUESTFROM_ID",
                principalTable: "REQUESTFORM",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "REQUESTFORM_OFFERS_REQUESTFORMID",
                table: "OFFERS",
                column: "REQUESTFORM_ID",
                principalTable: "REQUESTFORM",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "DEPARTMENT_PRODUCTS_DEPARTMENTID",
                table: "PRODUCTS",
                column: "DEPARTMENT_ID",
                principalTable: "DEPARTMENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "DEPARTMENT_REPORTS_PERSONID",
                table: "REPORTS",
                column: "DEPARTMENT_ID",
                principalTable: "DEPARTMENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "PERSON_REPORTS_PERSONID",
                table: "REPORTS",
                column: "PERSON_ID",
                principalTable: "PERSONS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "PERSON_REQUESTFORMS_PERSONID",
                table: "REQUESTFORM",
                column: "PERSON_ID",
                principalTable: "PERSONS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "REQUESTFORM_INVOICES_REQUESTFORMID",
                table: "INVOICES");

            migrationBuilder.DropForeignKey(
                name: "REQUESTFORM_OFFERS_REQUESTFORMID",
                table: "OFFERS");

            migrationBuilder.DropForeignKey(
                name: "DEPARTMENT_PRODUCTS_DEPARTMENTID",
                table: "PRODUCTS");

            migrationBuilder.DropForeignKey(
                name: "DEPARTMENT_REPORTS_PERSONID",
                table: "REPORTS");

            migrationBuilder.DropForeignKey(
                name: "PERSON_REPORTS_PERSONID",
                table: "REPORTS");

            migrationBuilder.DropForeignKey(
                name: "PERSON_REQUESTFORMS_PERSONID",
                table: "REQUESTFORM");

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICES_REQUESTFORM_REQUESTFROM_ID",
                table: "INVOICES",
                column: "REQUESTFROM_ID",
                principalTable: "REQUESTFORM",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OFFERS_REQUESTFORM_REQUESTFORM_ID",
                table: "OFFERS",
                column: "REQUESTFORM_ID",
                principalTable: "REQUESTFORM",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_DEPARTMENT_DEPARTMENT_ID",
                table: "PRODUCTS",
                column: "DEPARTMENT_ID",
                principalTable: "DEPARTMENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_REPORTS_DEPARTMENT_DEPARTMENT_ID",
                table: "REPORTS",
                column: "DEPARTMENT_ID",
                principalTable: "DEPARTMENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "yeni",
                table: "REPORTS",
                column: "PERSON_ID",
                principalTable: "PERSONS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_REQUESTFORM_PERSONS_PERSON_ID",
                table: "REQUESTFORM",
                column: "PERSON_ID",
                principalTable: "PERSONS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

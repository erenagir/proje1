using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REQUESTFORM_INVOICES_InvoiceId",
                table: "REQUESTFORM");

            migrationBuilder.DropIndex(
                name: "IX_REQUESTFORM_InvoiceId",
                table: "REQUESTFORM");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "REQUESTFORM");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_DETAİL",
                table: "INVOICES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "INVOICE_DATE",
                table: "INVOICES",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "COMPANY_NAME",
                table: "INVOICES",
                type: "nvarchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<int>(
                name: "REQUESTFROM_ID",
                table: "INVOICES",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "RequestFormId1",
                table: "INVOICES",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "INVOICES",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_RequestFormId1",
                table: "INVOICES",
                column: "RequestFormId1",
                unique: true,
                filter: "[RequestFormId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_REQUESTFROM_ID",
                table: "INVOICES",
                column: "REQUESTFROM_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICES_REQUESTFORM_REQUESTFROM_ID",
                table: "INVOICES",
                column: "REQUESTFROM_ID",
                principalTable: "REQUESTFORM",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICES_REQUESTFORM_RequestFormId1",
                table: "INVOICES",
                column: "RequestFormId1",
                principalTable: "REQUESTFORM",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICES_REQUESTFORM_REQUESTFROM_ID",
                table: "INVOICES");

            migrationBuilder.DropForeignKey(
                name: "FK_INVOICES_REQUESTFORM_RequestFormId1",
                table: "INVOICES");

            migrationBuilder.DropIndex(
                name: "IX_INVOICES_RequestFormId1",
                table: "INVOICES");

            migrationBuilder.DropIndex(
                name: "IX_INVOICES_REQUESTFROM_ID",
                table: "INVOICES");

            migrationBuilder.DropColumn(
                name: "REQUESTFROM_ID",
                table: "INVOICES");

            migrationBuilder.DropColumn(
                name: "RequestFormId1",
                table: "INVOICES");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "INVOICES");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "REQUESTFORM",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCT_DETAİL",
                table: "INVOICES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "INVOICE_DATE",
                table: "INVOICES",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "COMPANY_NAME",
                table: "INVOICES",
                type: "nvarchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTFORM_InvoiceId",
                table: "REQUESTFORM",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_REQUESTFORM_INVOICES_InvoiceId",
                table: "REQUESTFORM",
                column: "InvoiceId",
                principalTable: "INVOICES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

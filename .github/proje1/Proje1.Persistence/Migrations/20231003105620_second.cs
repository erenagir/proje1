using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "REQUESTFORM");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "OFFERS");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "REQUESTFORM",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "PRODUCTS",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "OFFERS",
                newName: "CREATE_DATE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_DATE",
                table: "REQUESTFORM",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "REQUESTFORM",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 37);

            migrationBuilder.AddColumn<string>(
                name: "CREATE_BY",
                table: "REQUESTFORM",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 36);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_DATE",
                table: "PRODUCTS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "PRODUCTS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 37);

            migrationBuilder.AddColumn<string>(
                name: "CREATE_BY",
                table: "PRODUCTS",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 36);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_DATE",
                table: "OFFERS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATE_DATE",
                table: "OFFERS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 37);

            migrationBuilder.AddColumn<string>(
                name: "CREATE_BY",
                table: "OFFERS",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 36);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATE_BY",
                table: "REQUESTFORM");

            migrationBuilder.DropColumn(
                name: "CREATE_BY",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "CREATE_BY",
                table: "OFFERS");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "REQUESTFORM",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "PRODUCTS",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "OFFERS",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_DATE",
                table: "REQUESTFORM",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "REQUESTFORM",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 37);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "REQUESTFORM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_DATE",
                table: "PRODUCTS",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PRODUCTS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 37);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "PRODUCTS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_DATE",
                table: "OFFERS",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "OFFERS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 37);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "OFFERS",
                type: "datetime2",
                nullable: true);
        }
    }
}

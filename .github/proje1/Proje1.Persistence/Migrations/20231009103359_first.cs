using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUTHORITY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    IS_ADMIN = table.Column<bool>(type: "bit", nullable: false),
                    IS_REQUEST = table.Column<bool>(type: "bit", nullable: false),
                    IS_APPROVE = table.Column<bool>(type: "bit", nullable: false),
                    IS_RECEIVE = table.Column<bool>(type: "bit", nullable: false),
                    IS_ACCOUNTING = table.Column<bool>(type: "bit", nullable: false),
                    IS_MANAGEMENT = table.Column<bool>(type: "bit", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHORITY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_NAME = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_ID = table.Column<int>(type: "int", nullable: false),
                    DEPARTMANT_NAME = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DEPARTMENT_COMPANY_COMPANY_ID",
                        column: x => x.COMPANY_ID,
                        principalTable: "COMPANY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PERSONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EMAİL = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ROLES = table.Column<int>(type: "int", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONS", x => x.ID);
                    table.ForeignKey(
                        name: "PERSONS_Department_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPARTMENT",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PRODUCTDETAİL = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    STOCK = table.Column<int>(type: "int", nullable: false),
                    CREATE_BY = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_DEPARTMENT_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPARTMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REPORTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: false),
                    DETAİL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPORTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REPORTS_DEPARTMENT_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPARTMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_REPORTS_PERSONS_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "PERSONS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "REQUESTFORM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DETAİL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COMPANY_EMAİL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    CREATE_BY = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUESTFORM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REQUESTFORM_PERSONS_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "PERSONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INVOICES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUESTFROM_ID = table.Column<int>(type: "int", nullable: false),
                    INVOICE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COMPANY_NAME = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    PRODUCT_DETAİL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOTAL_PRİCE = table.Column<double>(type: "float", nullable: false),
                    CREATE_BY = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INVOICES_REQUESTFORM_REQUESTFROM_ID",
                        column: x => x.REQUESTFROM_ID,
                        principalTable: "REQUESTFORM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OFFERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUESTFORM_ID = table.Column<int>(type: "int", nullable: false),
                    COMPANY_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    COMPANY_EMAİL = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    COMPANY_PHONE = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    TOTAL_PRICE = table.Column<double>(type: "float", nullable: false),
                    CREATE_BY = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFFERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OFFERS_REQUESTFORM_REQUESTFORM_ID",
                        column: x => x.REQUESTFORM_ID,
                        principalTable: "REQUESTFORM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENT_COMPANY_ID",
                table: "DEPARTMENT",
                column: "COMPANY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_REQUESTFROM_ID",
                table: "INVOICES",
                column: "REQUESTFROM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_REQUESTFORM_ID",
                table: "OFFERS",
                column: "REQUESTFORM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONS_DEPARTMENT_ID",
                table: "PERSONS",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_DEPARTMENT_ID",
                table: "PRODUCTS",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REPORTS_DEPARTMENT_ID",
                table: "REPORTS",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REPORTS_PERSON_ID",
                table: "REPORTS",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTFORM_PERSON_ID",
                table: "REQUESTFORM",
                column: "PERSON_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUTHORITY");

            migrationBuilder.DropTable(
                name: "INVOICES");

            migrationBuilder.DropTable(
                name: "OFFERS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "REPORTS");

            migrationBuilder.DropTable(
                name: "REQUESTFORM");

            migrationBuilder.DropTable(
                name: "PERSONS");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "COMPANY");
        }
    }
}

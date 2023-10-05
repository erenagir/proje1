using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUTHORİTY_PERSONS_PERSON_ID",
                table: "AUTHORİTY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AUTHORİTY",
                table: "AUTHORİTY");

            migrationBuilder.RenameTable(
                name: "AUTHORİTY",
                newName: "AUTHORITY");

            migrationBuilder.RenameColumn(
                name: "IS_RECEİVE",
                table: "AUTHORITY",
                newName: "IS_RECEIVE");

            migrationBuilder.RenameColumn(
                name: "IS_ADMİN",
                table: "AUTHORITY",
                newName: "IS_ADMIN");

            migrationBuilder.RenameColumn(
                name: "IS_ACCOUNTİNG",
                table: "AUTHORITY",
                newName: "IS_ACCOUNTING");

            migrationBuilder.RenameIndex(
                name: "IX_AUTHORİTY_PERSON_ID",
                table: "AUTHORITY",
                newName: "IX_AUTHORITY_PERSON_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AUTHORITY",
                table: "AUTHORITY",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AUTHORITY_PERSONS_PERSON_ID",
                table: "AUTHORITY",
                column: "PERSON_ID",
                principalTable: "PERSONS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUTHORITY_PERSONS_PERSON_ID",
                table: "AUTHORITY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AUTHORITY",
                table: "AUTHORITY");

            migrationBuilder.RenameTable(
                name: "AUTHORITY",
                newName: "AUTHORİTY");

            migrationBuilder.RenameColumn(
                name: "IS_RECEIVE",
                table: "AUTHORİTY",
                newName: "IS_RECEİVE");

            migrationBuilder.RenameColumn(
                name: "IS_ADMIN",
                table: "AUTHORİTY",
                newName: "IS_ADMİN");

            migrationBuilder.RenameColumn(
                name: "IS_ACCOUNTING",
                table: "AUTHORİTY",
                newName: "IS_ACCOUNTİNG");

            migrationBuilder.RenameIndex(
                name: "IX_AUTHORITY_PERSON_ID",
                table: "AUTHORİTY",
                newName: "IX_AUTHORİTY_PERSON_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AUTHORİTY",
                table: "AUTHORİTY",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AUTHORİTY_PERSONS_PERSON_ID",
                table: "AUTHORİTY",
                column: "PERSON_ID",
                principalTable: "PERSONS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

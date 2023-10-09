using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REPORTS_PERSONS_PERSON_ID",
                table: "REPORTS");

            migrationBuilder.AddForeignKey(
                name: "yeni",
                table: "REPORTS",
                column: "PERSON_ID",
                principalTable: "PERSONS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "yeni",
                table: "REPORTS");

            migrationBuilder.AddForeignKey(
                name: "FK_REPORTS_PERSONS_PERSON_ID",
                table: "REPORTS",
                column: "PERSON_ID",
                principalTable: "PERSONS",
                principalColumn: "ID");
        }
    }
}

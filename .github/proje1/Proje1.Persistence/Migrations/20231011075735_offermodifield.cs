using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje1.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class offermodifield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OFFER_STATUS",
                table: "OFFERS",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 9);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OFFER_STATUS",
                table: "OFFERS");
        }
    }
}

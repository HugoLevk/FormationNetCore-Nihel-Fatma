using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnneeConstructionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_typeBien",
                table: "BienImmobiliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "anneeCOnstruction",
                table: "BienImmobiliers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_typeBien",
                table: "BienImmobiliers");

            migrationBuilder.DropColumn(
                name: "anneeCOnstruction",
                table: "BienImmobiliers");
        }
    }
}

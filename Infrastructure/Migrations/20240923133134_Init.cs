using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estActive = table.Column<bool>(type: "bit", nullable: false),
                    contactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_numeroRue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_Rue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_codePostal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BienImmobiliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomAnnonce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse_Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_numeroRue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_Rue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_codePostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pourParticulier = table.Column<bool>(type: "bit", nullable: false),
                    isLocation = table.Column<bool>(type: "bit", nullable: false),
                    prixLocatif = table.Column<decimal>(type: "numeric(2,0)", precision: 2, nullable: false),
                    prixVente = table.Column<decimal>(type: "numeric(2,0)", precision: 2, nullable: false),
                    RegieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BienImmobiliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BienImmobiliers_Regies_RegieId",
                        column: x => x.RegieId,
                        principalTable: "Regies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BienImmobiliers_RegieId",
                table: "BienImmobiliers",
                column: "RegieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BienImmobiliers");

            migrationBuilder.DropTable(
                name: "Regies");
        }
    }
}

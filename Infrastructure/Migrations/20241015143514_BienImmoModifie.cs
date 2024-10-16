using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BienImmoModifie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BienImmobiliers",
                table: "BienImmobiliers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BienImmobiliers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BienImmobiliers",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BienImmobiliers",
                table: "BienImmobiliers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BienImmobiliers",
                table: "BienImmobiliers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BienImmobiliers");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BienImmobiliers",
                type: "uniqueidentifier",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BienImmobiliers",
                table: "BienImmobiliers",
                column: "Id");
        }
    }
}

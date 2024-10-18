using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OwnerAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Regies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "c8aa6271-abe5-44a0-876f-ab0f8457c56d");

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_Regies_OwnerId",
                table: "Regies",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regies_AspNetUsers_OwnerId",
                table: "Regies",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regies_AspNetUsers_OwnerId",
                table: "Regies");

            migrationBuilder.DropIndex(
                name: "IX_Regies_OwnerId",
                table: "Regies");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Regies");

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}

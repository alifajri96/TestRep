using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Test.Data.Migrations
{
    public partial class addkategori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategori_Artikel_ID_Artikel",
                table: "Kategori");

            migrationBuilder.DropIndex(
                name: "IX_Kategori_ID_Artikel",
                table: "Kategori");

            migrationBuilder.DropColumn(
                name: "ID_Artikel",
                table: "Kategori");

            migrationBuilder.AddColumn<int>(
                name: "ID_Kategori",
                table: "Artikel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artikel_ID_Kategori",
                table: "Artikel",
                column: "ID_Kategori");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikel_Kategori_ID_Kategori",
                table: "Artikel",
                column: "ID_Kategori",
                principalTable: "Kategori",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikel_Kategori_ID_Kategori",
                table: "Artikel");

            migrationBuilder.DropIndex(
                name: "IX_Artikel_ID_Kategori",
                table: "Artikel");

            migrationBuilder.DropColumn(
                name: "ID_Kategori",
                table: "Artikel");

            migrationBuilder.AddColumn<int>(
                name: "ID_Artikel",
                table: "Kategori",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kategori_ID_Artikel",
                table: "Kategori",
                column: "ID_Artikel");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategori_Artikel_ID_Artikel",
                table: "Kategori",
                column: "ID_Artikel",
                principalTable: "Artikel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

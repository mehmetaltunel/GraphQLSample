using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQL.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class FirstCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    ListingPrice = table.Column<float>(type: "real", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 6, 17, 2, 18, 732, DateTimeKind.Local).AddTicks(6731), "meyve suyu", true, false, "Meyve Suları", null },
                    { 2, new DateTime(2023, 4, 6, 17, 2, 18, 732, DateTimeKind.Local).AddTicks(6744), null, true, false, "Gazlı İçecek", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "CreatedDate", "Description", "IsActive", "IsDeleted", "ListingPrice", "Name", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, "CP2", null, "capy ailesine ait karışık meyve suyu", null, null, 20f, "Cappy Karışık", 14.5f, null },
                    { 2, 2, "CC1", null, null, null, null, 25f, "Coca Cola 1 Litre", 20.5f, null },
                    { 3, 2, "CC1", null, null, null, null, 35f, "Coca Cola 2.5 Litre", 30.5f, null },
                    { 4, 1, "F1", null, "fruko gazoz", null, null, 28f, "Fruko", 23.5f, null },
                    { 5, 1, "CP1", null, "capy ailesine ait şeftalili meyve suyu", null, null, 20f, "Cappy Şeftali", 14.5f, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

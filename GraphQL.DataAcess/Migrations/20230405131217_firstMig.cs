using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQL.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class firstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Roll = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "Name", "Roll", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 5, 16, 12, 17, 823, DateTimeKind.Local).AddTicks(8256), true, false, "Mehmet", "1001", null },
                    { 2, new DateTime(2023, 4, 5, 16, 12, 17, 823, DateTimeKind.Local).AddTicks(8268), true, false, "Ahmet", "1002", null },
                    { 3, new DateTime(2023, 4, 5, 16, 12, 17, 823, DateTimeKind.Local).AddTicks(8270), true, false, "Maho", "1003", null },
                    { 4, new DateTime(2023, 4, 5, 16, 12, 17, 823, DateTimeKind.Local).AddTicks(8272), true, false, "Ümido", "1004", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

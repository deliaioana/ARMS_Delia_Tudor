using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LifeExpectancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LifeExpectancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    CountryFieldId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaleLifeExpectancy = table.Column<float>(type: "REAL", nullable: false),
                    FemaleLifeExpectancy = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeExpectancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LifeExpectancies_Countries_CountryFieldId",
                        column: x => x.CountryFieldId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LifeExpectancies_CountryFieldId",
                table: "LifeExpectancies",
                column: "CountryFieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LifeExpectancies");
        }
    }
}

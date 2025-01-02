using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympicGames.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class areacountrylistremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Areas_AreaId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_AreaId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CountryId",
                table: "Areas",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Countries_CountryId",
                table: "Areas",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Countries_CountryId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_CountryId",
                table: "Areas");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_AreaId",
                table: "Countries",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Areas_AreaId",
                table: "Countries",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlympicGames.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class athletelistremovedfromgamecountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Athletes_AthleteId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Athletes_AthleteId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_AthleteId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Countries_AthleteId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "AthleteId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AthleteId",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_CountryId",
                table: "Athletes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_GameId",
                table: "Athletes",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Countries_CountryId",
                table: "Athletes",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Games_GameId",
                table: "Athletes",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Countries_CountryId",
                table: "Athletes");

            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Games_GameId",
                table: "Athletes");

            migrationBuilder.DropIndex(
                name: "IX_Athletes_CountryId",
                table: "Athletes");

            migrationBuilder.DropIndex(
                name: "IX_Athletes_GameId",
                table: "Athletes");

            migrationBuilder.AddColumn<int>(
                name: "AthleteId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AthleteId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_AthleteId",
                table: "Games",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_AthleteId",
                table: "Countries",
                column: "AthleteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Athletes_AthleteId",
                table: "Countries",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Athletes_AthleteId",
                table: "Games",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id");
        }
    }
}

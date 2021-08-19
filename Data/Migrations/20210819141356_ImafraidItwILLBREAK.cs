using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ImafraidItwILLBREAK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MovieFavourites_MovieId",
                table: "MovieFavourites",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieFavourites_UserId",
                table: "MovieFavourites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieFavourites_Movies_MovieId",
                table: "MovieFavourites",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieFavourites_Users_UserId",
                table: "MovieFavourites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieFavourites_Movies_MovieId",
                table: "MovieFavourites");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieFavourites_Users_UserId",
                table: "MovieFavourites");

            migrationBuilder.DropIndex(
                name: "IX_MovieFavourites_MovieId",
                table: "MovieFavourites");

            migrationBuilder.DropIndex(
                name: "IX_MovieFavourites_UserId",
                table: "MovieFavourites");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBGList.Migrations
{
    public partial class RenamePropertiesInBoardGameEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Mechanics",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Domains",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UserRated",
                table: "BoardGames",
                newName: "UsersRated");

            migrationBuilder.RenameColumn(
                name: "OwnedUser",
                table: "BoardGames",
                newName: "OwnedUsers");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BoardGames",
                newName: "CreatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Mechanics",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Domains",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UsersRated",
                table: "BoardGames",
                newName: "UserRated");

            migrationBuilder.RenameColumn(
                name: "OwnedUsers",
                table: "BoardGames",
                newName: "OwnedUser");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "BoardGames",
                newName: "CreatedAt");
        }
    }
}

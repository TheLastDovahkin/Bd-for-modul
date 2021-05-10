using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bd_for_modul.Migrations
{
    public partial class started : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "Time", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SongGenre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Song_Genre_SongGenre",
                        column: x => x.SongGenre,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_Supply_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supply_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_SongGenre",
                table: "Song",
                column: "SongGenre");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_SongId",
                table: "Supply",
                column: "SongId");

            migrationBuilder.Sql(@"INSERT INTO Artist(Name, DateOfBirth, Phone, Email, InstagramURL) VALUES('Some Samuel', '1999-12-11', '+65564866', 'BigWhiteAss@gmail.com', 'IDK@com')");

            migrationBuilder.Sql(@"INSERT INTO Genre(Title) VALUES ('RealBlackSong')");

            migrationBuilder.Sql(@"INSERT INTO Song(SongTitle, Duration, ReleasedDate, SongGenre) VALUES('IAMNOTRASIC', CAST('00:00:11' as TIME), CAST('2021-05-10' as DATE), (SELECT GenreId FROM Genre WHERE Title = 'RealBlackSong'))");

            migrationBuilder.Sql(@"INSERT INTO Supply(ArtistId, SongId) VALUES((SELECT ArtistId FROM Artist WHERE Name = 'Some Samuel'), (SELECT SongId FROM Song WHERE SongTitle = 'IAMNOTRASIC'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}

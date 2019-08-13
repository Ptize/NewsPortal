using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsPortal.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Newss",
                columns: table => new
                {
                    NewsId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Photo = table.Column<byte>(nullable: false),
                    Headline = table.Column<string>(nullable: true),
                    Review = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newss", x => x.NewsId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Newss_NewsId",
                table: "Newss",
                column: "NewsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Newss");
        }
    }
}

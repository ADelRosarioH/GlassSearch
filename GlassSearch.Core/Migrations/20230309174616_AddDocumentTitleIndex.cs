using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlassSearch.Core.Migrations
{
    public partial class AddDocumentTitleIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Documents_Title",
                table: "Documents",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_Title",
                table: "Documents");
        }
    }
}

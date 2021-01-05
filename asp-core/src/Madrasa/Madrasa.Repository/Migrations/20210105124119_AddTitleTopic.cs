using Microsoft.EntityFrameworkCore.Migrations;

namespace Madrasa.Repository.Migrations
{
    public partial class AddTitleTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Topics");
        }
    }
}

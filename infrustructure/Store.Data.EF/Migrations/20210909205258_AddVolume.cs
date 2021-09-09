using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.EF.Migrations
{
    public partial class AddVolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Volume",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Products");
        }
    }
}

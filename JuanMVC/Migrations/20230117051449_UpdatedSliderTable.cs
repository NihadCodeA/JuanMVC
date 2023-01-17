using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuanMVC.Migrations
{
    public partial class UpdatedSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ButtonUrl",
                table: "Sliders",
                newName: "RedirectUrl");

            migrationBuilder.RenameColumn(
                name: "ButtonText",
                table: "Sliders",
                newName: "RedirectText");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RedirectUrl",
                table: "Sliders",
                newName: "ButtonUrl");

            migrationBuilder.RenameColumn(
                name: "RedirectText",
                table: "Sliders",
                newName: "ButtonText");
        }
    }
}

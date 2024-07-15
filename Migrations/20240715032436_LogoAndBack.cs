using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Cecilious.Migrations
{
    /// <inheritdoc />
    public partial class LogoAndBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Restaurant");
        }
    }
}

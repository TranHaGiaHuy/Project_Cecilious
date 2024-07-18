using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Cecilious.Migrations
{
    /// <inheritdoc />
    public partial class updatereviewId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ReviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Review");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                columns: new[] { "UserId", "RestaurantId" });
        }
    }
}

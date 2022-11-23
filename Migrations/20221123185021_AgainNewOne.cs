using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TORCHAIN.Migrations
{
    /// <inheritdoc />
    public partial class AgainNewOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "DarknetGallery",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "DarknetGallery");
        }
    }
}

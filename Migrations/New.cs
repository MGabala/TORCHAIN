using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TORCHAIN.Migrations
{
    /// <inheritdoc />
    public partial class NewOneKsodakosadkoads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DarknetGalleryEntities",
                table: "DarknetGalleryEntities");

            migrationBuilder.RenameTable(
                name: "DarknetGalleryEntities",
                newName: "DarknetGallery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DarknetGallery",
                table: "DarknetGallery",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DarknetGallery",
                table: "DarknetGallery");

            migrationBuilder.RenameTable(
                name: "DarknetGallery",
                newName: "DarknetGalleryEntities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DarknetGalleryEntities",
                table: "DarknetGalleryEntities",
                column: "Id");
        }
    }
}

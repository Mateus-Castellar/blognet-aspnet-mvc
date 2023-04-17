using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogNet.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FotoPerfilTabelaUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "AspNetUsers",
                type: "varchar(255)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "AspNetUsers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "SenderImageUrl",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderImageUrl",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "ProjectImage",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

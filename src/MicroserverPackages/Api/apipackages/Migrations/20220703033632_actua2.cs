using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apipackages.Migrations
{
    public partial class actua2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeVerify",
                table: "Employes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeVerify",
                table: "Employes");
        }
    }
}

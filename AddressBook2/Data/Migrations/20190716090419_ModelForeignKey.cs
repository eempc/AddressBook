using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook2.Data.Migrations
{
    public partial class ModelForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForeignKey",
                table: "Contact",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForeignKey",
                table: "Contact");
        }
    }
}

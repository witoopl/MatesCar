using Microsoft.EntityFrameworkCore.Migrations;

namespace MatesCarSite.Migrations
{
    public partial class Moved_IsPaid_From_Routes_To_Debts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFullyPaid",
                table: "Routes");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Debts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Debts");

            migrationBuilder.AddColumn<bool>(
                name: "IsFullyPaid",
                table: "Routes",
                nullable: false,
                defaultValue: false);
        }
    }
}

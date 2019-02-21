using Microsoft.EntityFrameworkCore.Migrations;

namespace MatesCarSite.Migrations
{
    public partial class ChagingDriverFromStringToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Driver",
                table: "Routes",
                newName: "DriverId");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Routes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DriverId",
                table: "Routes",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_AspNetUsers_DriverId",
                table: "Routes",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_AspNetUsers_DriverId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_DriverId",
                table: "Routes");

            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Routes",
                newName: "Driver");

            migrationBuilder.AlterColumn<string>(
                name: "Driver",
                table: "Routes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

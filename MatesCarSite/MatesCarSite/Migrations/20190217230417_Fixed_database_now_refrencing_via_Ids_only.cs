using Microsoft.EntityFrameworkCore.Migrations;

namespace MatesCarSite.Migrations
{
    public partial class Fixed_database_now_refrencing_via_Ids_only : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Debts_DebtId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Routes_RouteId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Debts_AspNetUsers_NameOfLoanHolderId",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Routes_RouteId",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_AspNetUsers_DriverId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_DriverId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Debts_NameOfLoanHolderId",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Debts_RouteId",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DebtId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RouteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DebtId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "NameOfLoanHolderId",
                table: "Debts",
                newName: "IdLoanHolder");

            migrationBuilder.AddColumn<string>(
                name: "Driver",
                table: "Routes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RouteId",
                table: "Debts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdLoanHolder",
                table: "Debts",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "IdLoanDebtor",
                table: "Debts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Driver",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "IdLoanDebtor",
                table: "Debts");

            migrationBuilder.RenameColumn(
                name: "IdLoanHolder",
                table: "Debts",
                newName: "NameOfLoanHolderId");

            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "Routes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RouteId",
                table: "Debts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameOfLoanHolderId",
                table: "Debts",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebtId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RouteId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DriverId",
                table: "Routes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_NameOfLoanHolderId",
                table: "Debts",
                column: "NameOfLoanHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_RouteId",
                table: "Debts",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DebtId",
                table: "AspNetUsers",
                column: "DebtId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RouteId",
                table: "AspNetUsers",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Debts_DebtId",
                table: "AspNetUsers",
                column: "DebtId",
                principalTable: "Debts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Routes_RouteId",
                table: "AspNetUsers",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_AspNetUsers_NameOfLoanHolderId",
                table: "Debts",
                column: "NameOfLoanHolderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_Routes_RouteId",
                table: "Debts",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_AspNetUsers_DriverId",
                table: "Routes",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

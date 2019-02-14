using Microsoft.EntityFrameworkCore.Migrations;

namespace MatesCarSite.Migrations
{
    public partial class ChagedPassengersIntoApplicationUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_AspNetUsers_AssociatedUserId",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Debts_AssociatedUserId",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "NonAppPassengers",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "AssociatedUserId",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "NameOfDebtor",
                table: "Debts");

            migrationBuilder.RenameColumn(
                name: "NameOfLoanHolder",
                table: "Debts",
                newName: "NameOfLoanHolderId");

            migrationBuilder.AlterColumn<string>(
                name: "NameOfLoanHolderId",
                table: "Debts",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "DebtId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RouteId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Debts_NameOfLoanHolderId",
                table: "Debts",
                column: "NameOfLoanHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DebtId",
                table: "AspNetUsers",
                column: "DebtId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RouteId",
                table: "AspNetUsers",
                column: "RouteId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Debts_DebtId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Routes_RouteId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Debts_AspNetUsers_NameOfLoanHolderId",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Debts_NameOfLoanHolderId",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DebtId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RouteId",
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
                newName: "NameOfLoanHolder");

            migrationBuilder.AddColumn<string>(
                name: "NonAppPassengers",
                table: "Routes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "NameOfLoanHolder",
                table: "Debts",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AssociatedUserId",
                table: "Debts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfDebtor",
                table: "Debts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_AssociatedUserId",
                table: "Debts",
                column: "AssociatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_AspNetUsers_AssociatedUserId",
                table: "Debts",
                column: "AssociatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

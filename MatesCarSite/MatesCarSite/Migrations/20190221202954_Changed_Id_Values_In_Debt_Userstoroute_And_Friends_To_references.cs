using Microsoft.EntityFrameworkCore.Migrations;

namespace MatesCarSite.Migrations
{
    public partial class Changed_Id_Values_In_Debt_Userstoroute_And_Friends_To_references : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "UsersToRoutes",
                newName: "RouteRefId");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "UsersToRoutes",
                newName: "PassengerRefId");

            migrationBuilder.RenameColumn(
                name: "UserFriend",
                table: "Friends",
                newName: "UserRefId");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Friends",
                newName: "UserFriendRefId");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "Debts",
                newName: "RouteRefId");

            migrationBuilder.RenameColumn(
                name: "IdLoanHolder",
                table: "Debts",
                newName: "LoanHolderRefId");

            migrationBuilder.RenameColumn(
                name: "IdLoanDebtor",
                table: "Debts",
                newName: "LoanDebtorRefId");

            migrationBuilder.AlterColumn<string>(
                name: "RouteRefId",
                table: "UsersToRoutes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassengerRefId",
                table: "UsersToRoutes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserRefId",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserFriendRefId",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RouteRefId",
                table: "Debts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoanHolderRefId",
                table: "Debts",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoanDebtorRefId",
                table: "Debts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersToRoutes_PassengerRefId",
                table: "UsersToRoutes",
                column: "PassengerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToRoutes_RouteRefId",
                table: "UsersToRoutes",
                column: "RouteRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserFriendRefId",
                table: "Friends",
                column: "UserFriendRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserRefId",
                table: "Friends",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_LoanDebtorRefId",
                table: "Debts",
                column: "LoanDebtorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_LoanHolderRefId",
                table: "Debts",
                column: "LoanHolderRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_RouteRefId",
                table: "Debts",
                column: "RouteRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_AspNetUsers_LoanDebtorRefId",
                table: "Debts",
                column: "LoanDebtorRefId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_AspNetUsers_LoanHolderRefId",
                table: "Debts",
                column: "LoanHolderRefId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_Routes_RouteRefId",
                table: "Debts",
                column: "RouteRefId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserFriendRefId",
                table: "Friends",
                column: "UserFriendRefId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserRefId",
                table: "Friends",
                column: "UserRefId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToRoutes_AspNetUsers_PassengerRefId",
                table: "UsersToRoutes",
                column: "PassengerRefId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToRoutes_Routes_RouteRefId",
                table: "UsersToRoutes",
                column: "RouteRefId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_AspNetUsers_LoanDebtorRefId",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_Debts_AspNetUsers_LoanHolderRefId",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Routes_RouteRefId",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserFriendRefId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserRefId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersToRoutes_AspNetUsers_PassengerRefId",
                table: "UsersToRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersToRoutes_Routes_RouteRefId",
                table: "UsersToRoutes");

            migrationBuilder.DropIndex(
                name: "IX_UsersToRoutes_PassengerRefId",
                table: "UsersToRoutes");

            migrationBuilder.DropIndex(
                name: "IX_UsersToRoutes_RouteRefId",
                table: "UsersToRoutes");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserFriendRefId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserRefId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Debts_LoanDebtorRefId",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Debts_LoanHolderRefId",
                table: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_Debts_RouteRefId",
                table: "Debts");

            migrationBuilder.RenameColumn(
                name: "RouteRefId",
                table: "UsersToRoutes",
                newName: "RouteId");

            migrationBuilder.RenameColumn(
                name: "PassengerRefId",
                table: "UsersToRoutes",
                newName: "PassengerId");

            migrationBuilder.RenameColumn(
                name: "UserRefId",
                table: "Friends",
                newName: "UserFriend");

            migrationBuilder.RenameColumn(
                name: "UserFriendRefId",
                table: "Friends",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "RouteRefId",
                table: "Debts",
                newName: "RouteId");

            migrationBuilder.RenameColumn(
                name: "LoanHolderRefId",
                table: "Debts",
                newName: "IdLoanHolder");

            migrationBuilder.RenameColumn(
                name: "LoanDebtorRefId",
                table: "Debts",
                newName: "IdLoanDebtor");

            migrationBuilder.AlterColumn<string>(
                name: "RouteId",
                table: "UsersToRoutes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassengerId",
                table: "UsersToRoutes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserFriend",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Friends",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "IdLoanDebtor",
                table: "Debts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

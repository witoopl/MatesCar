using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MatesCarSite.Migrations
{
    public partial class SecondVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cars_CarId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Cars_CarId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_AspNetUsers_DriverId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_AspNetUsers_PassengerId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Roads_RoadId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Roads");

            migrationBuilder.DropIndex(
                name: "IX_Routes_CarId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_PassengerId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_RoadId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CarId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RoadId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "BankAccountVerificated",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLocation",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Routes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ChargeForPassenger",
                table: "Routes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "EndLocation",
                table: "Routes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "FuelUsage",
                table: "Routes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "IsFullyPaid",
                table: "Routes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NonAppPassengers",
                table: "Routes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartLocation",
                table: "Routes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RouteId",
                table: "Debts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DefaultBankAccount",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Debts_RouteId",
                table: "Debts",
                column: "RouteId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Routes_RouteId",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_AspNetUsers_DriverId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Debts_RouteId",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "ChargeForPassenger",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "EndLocation",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "FuelUsage",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "IsFullyPaid",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "NonAppPassengers",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "StartLocation",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Debts");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Routes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "Routes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassengerId",
                table: "Routes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoadId",
                table: "Routes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DefaultBankAccount",
                table: "AspNetUsers",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BankAccountVerificated",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastLocation",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Brand = table.Column<int>(nullable: false),
                    FuelConsumptionForRoad = table.Column<float>(nullable: true),
                    FuelConsumptionGeneral = table.Column<float>(nullable: false),
                    FuelConsumptionInCity = table.Column<float>(nullable: true),
                    Model = table.Column<string>(maxLength: 32, nullable: true),
                    NumberOfSeats = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roads",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Distance = table.Column<float>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roads", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CarId",
                table: "Routes",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_PassengerId",
                table: "Routes",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RoadId",
                table: "Routes",
                column: "RoadId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CarId",
                table: "AspNetUsers",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cars_CarId",
                table: "AspNetUsers",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Cars_CarId",
                table: "Routes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_AspNetUsers_DriverId",
                table: "Routes",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_AspNetUsers_PassengerId",
                table: "Routes",
                column: "PassengerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Roads_RoadId",
                table: "Routes",
                column: "RoadId",
                principalTable: "Roads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

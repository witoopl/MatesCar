using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MatesCarSite.Migrations
{
    public partial class Correction_UserFirstName_UserSurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "USurnameName",
                table: "AspNetUsers",
                newName: "UserSurname");

            migrationBuilder.RenameColumn(
                name: "UName",
                table: "AspNetUsers",
                newName: "UserFirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserSurname",
                table: "AspNetUsers",
                newName: "USurnameName");

            migrationBuilder.RenameColumn(
                name: "UserFirstName",
                table: "AspNetUsers",
                newName: "UName");
        }
    }
}

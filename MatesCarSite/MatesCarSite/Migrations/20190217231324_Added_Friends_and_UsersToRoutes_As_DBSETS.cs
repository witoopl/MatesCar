using Microsoft.EntityFrameworkCore.Migrations;

namespace MatesCarSite.Migrations
{
    public partial class Added_Friends_and_UsersToRoutes_As_DBSETS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    UserFriend = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersToRoutes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RouteId = table.Column<string>(nullable: true),
                    PassengerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToRoutes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "UsersToRoutes");
        }
    }
}

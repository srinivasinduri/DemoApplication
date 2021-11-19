using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoApp.Model.Migrations
{
    public partial class Addedrelation_userprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FkRoleId",
                table: "userProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userProfiles_FkRoleId",
                table: "userProfiles",
                column: "FkRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_userProfiles_Roles_FkRoleId",
                table: "userProfiles",
                column: "FkRoleId",
                principalTable: "Roles",
                principalColumn: "PkRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userProfiles_Roles_FkRoleId",
                table: "userProfiles");

            migrationBuilder.DropIndex(
                name: "IX_userProfiles_FkRoleId",
                table: "userProfiles");

            migrationBuilder.DropColumn(
                name: "FkRoleId",
                table: "userProfiles");
        }
    }
}

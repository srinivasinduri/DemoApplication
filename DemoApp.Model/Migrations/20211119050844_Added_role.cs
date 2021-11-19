using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoApp.Model.Migrations
{
    public partial class Added_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "dbo");

            //migrationBuilder.CreateSequence<int>(
            //    name: "userProfiles",
            //    schema: "dbo",
            //    startValue: 0L);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRoleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropSequence(
                name: "userProfiles",
                schema: "dbo");
        }
    }
}

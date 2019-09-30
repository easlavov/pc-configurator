using Microsoft.EntityFrameworkCore.Migrations;

namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Migrations
{
    public partial class AddConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "configurations",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configurations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "configurations_components",
                columns: table => new
                {
                    configuration_id = table.Column<long>(nullable: false),
                    component_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configurations_components", x => new { x.component_id, x.configuration_id });
                    table.ForeignKey(
                        name: "FK_configurations_components_components_component_id",
                        column: x => x.component_id,
                        principalTable: "components",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_configurations_components_configurations_configuration_id",
                        column: x => x.configuration_id,
                        principalTable: "configurations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_configurations_components_configuration_id",
                table: "configurations_components",
                column: "configuration_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configurations_components");

            migrationBuilder.DropTable(
                name: "configurations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Migrations
{
    public partial class AddComponentTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "component_types",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_component_types", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "component_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1L, "Motherboard" },
                    { 2L, "CPU" },
                    { 3L, "GPU" },
                    { 4L, "RAM" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "component_types");
        }
    }
}

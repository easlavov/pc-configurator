using Microsoft.EntityFrameworkCore.Migrations;

namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Migrations
{
    public partial class AddComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "components",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    component_type_id = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_components", x => x.id);
                    table.ForeignKey(
                        name: "FK_components_component_types_component_type_id",
                        column: x => x.component_type_id,
                        principalTable: "component_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "components",
                columns: new[] { "id", "component_type_id", "name", "price" },
                values: new object[,]
                {
                    { 1L, 1L, "MSI Z390-A PRO", 200m },
                    { 2L, 2L, "AMD FX-8150", 150m },
                    { 3L, 2L, "Intel i5-6500T", 180m },
                    { 4L, 3L, "GTX 960", 230m },
                    { 5L, 4L, "Corsair Vengeance LED 16Gb (2x8GB) DDR4 3000MHz", 230m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_components_component_type_id",
                table: "components",
                column: "component_type_id",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "components");
        }
    }
}

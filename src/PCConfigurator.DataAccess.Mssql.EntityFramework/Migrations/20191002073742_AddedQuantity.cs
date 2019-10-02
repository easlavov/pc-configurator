using Microsoft.EntityFrameworkCore.Migrations;

namespace PCConfigurator.DataAccess.Mssql.EntityFramework.Migrations
{
    public partial class AddedQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_components_component_types_component_type_id",
                table: "components");

            migrationBuilder.DropIndex(
                name: "IX_components_component_type_id",
                table: "components");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "configurations_components",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_components_component_type_id",
                table: "components",
                column: "component_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_components_component_types_component_type_id",
                table: "components",
                column: "component_type_id",
                principalTable: "component_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_components_component_types_component_type_id",
                table: "components");

            migrationBuilder.DropIndex(
                name: "IX_components_component_type_id",
                table: "components");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "configurations_components");

            migrationBuilder.CreateIndex(
                name: "IX_components_component_type_id",
                table: "components",
                column: "component_type_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_components_component_types_component_type_id",
                table: "components",
                column: "component_type_id",
                principalTable: "component_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

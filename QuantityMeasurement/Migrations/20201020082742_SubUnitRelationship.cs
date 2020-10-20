using Microsoft.EntityFrameworkCore.Migrations;

namespace QuantityMeasurement.Migrations
{
    public partial class SubUnitRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainUnitId",
                table: "Subunits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subunits_MainUnitId",
                table: "Subunits",
                column: "MainUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subunits_MainUnits_MainUnitId",
                table: "Subunits",
                column: "MainUnitId",
                principalTable: "MainUnits",
                principalColumn: "MainUnitsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subunits_MainUnits_MainUnitId",
                table: "Subunits");

            migrationBuilder.DropIndex(
                name: "IX_Subunits_MainUnitId",
                table: "Subunits");

            migrationBuilder.DropColumn(
                name: "MainUnitId",
                table: "Subunits");
        }
    }
}

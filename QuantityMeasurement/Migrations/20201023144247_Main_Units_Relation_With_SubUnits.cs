using Microsoft.EntityFrameworkCore.Migrations;

namespace QuantityMeasurement.Migrations
{
    public partial class Main_Units_Relation_With_SubUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "SubUnitsValue",
                table: "Subunits",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "MainUnitsId",
                table: "Subunits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subunits_MainUnitsId",
                table: "Subunits",
                column: "MainUnitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subunits_MainUnits_MainUnitsId",
                table: "Subunits",
                column: "MainUnitsId",
                principalTable: "MainUnits",
                principalColumn: "MainUnitsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subunits_MainUnits_MainUnitsId",
                table: "Subunits");

            migrationBuilder.DropIndex(
                name: "IX_Subunits_MainUnitsId",
                table: "Subunits");

            migrationBuilder.DropColumn(
                name: "MainUnitsId",
                table: "Subunits");

            migrationBuilder.AlterColumn<float>(
                name: "SubUnitsValue",
                table: "Subunits",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "MainUnitId",
                table: "Subunits",
                type: "int",
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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace QuantityMeasurement.Migrations
{
    public partial class SubUnitValidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MainUnitName",
                table: "MainUnits",
                type: "varchar(200)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Subunits",
                columns: table => new
                {
                    SubunitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubunitName = table.Column<string>(type: "varchar(200)", maxLength: 50, nullable: false),
                    SubUnitsValue = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subunits", x => x.SubunitId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subunits");

            migrationBuilder.AlterColumn<string>(
                name: "MainUnitName",
                table: "MainUnits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 50);
        }
    }
}

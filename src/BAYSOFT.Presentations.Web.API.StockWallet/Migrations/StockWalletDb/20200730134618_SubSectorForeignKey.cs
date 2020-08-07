using Microsoft.EntityFrameworkCore.Migrations;

namespace BAYSOFT.Presentations.Web.API.StockWallet.Migrations.StockWalletDb
{
    public partial class SubSectorForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubSectors_Sectors_SectorID",
                table: "SubSectors");

            migrationBuilder.DropColumn(
                name: "SectionID",
                table: "SubSectors");

            migrationBuilder.AlterColumn<int>(
                name: "SectorID",
                table: "SubSectors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubSectors_Sectors_SectorID",
                table: "SubSectors",
                column: "SectorID",
                principalTable: "Sectors",
                principalColumn: "SectorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubSectors_Sectors_SectorID",
                table: "SubSectors");

            migrationBuilder.AlterColumn<int>(
                name: "SectorID",
                table: "SubSectors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SectionID",
                table: "SubSectors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SubSectors_Sectors_SectorID",
                table: "SubSectors",
                column: "SectorID",
                principalTable: "Sectors",
                principalColumn: "SectorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

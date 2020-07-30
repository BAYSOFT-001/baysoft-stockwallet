using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAYSOFT.Presentations.WebAPI.Migrations.StockWalletDb
{
    public partial class InitialStockWalletDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    SampleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.SampleID);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    SectorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.SectorID);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletID);
                });

            migrationBuilder.CreateTable(
                name: "SubSectors",
                columns: table => new
                {
                    SubSectorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    SectionID = table.Column<int>(nullable: false),
                    SectorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSectors", x => x.SubSectorID);
                    table.ForeignKey(
                        name: "FK_SubSectors_Sectors_SectorID",
                        column: x => x.SectorID,
                        principalTable: "Sectors",
                        principalColumn: "SectorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    SubSectionID = table.Column<int>(nullable: false),
                    SubSectorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockID);
                    table.ForeignKey(
                        name: "FK_Stocks_SubSectors_SubSectorID",
                        column: x => x.SubSectorID,
                        principalTable: "SubSectors",
                        principalColumn: "SubSectorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    StockID = table.Column<int>(nullable: false),
                    SectorAndQuality = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    RecommendedWallet = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    Dividend = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    ReturnOnEquity = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    ProfitLast5Years = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    NetMargin = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    Indebtedness = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    Overlap = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.StockID);
                    table.ForeignKey(
                        name: "FK_Grades_Stocks_StockID",
                        column: x => x.StockID,
                        principalTable: "Stocks",
                        principalColumn: "StockID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    IsPurchase = table.Column<bool>(nullable: false),
                    StockID = table.Column<int>(nullable: false),
                    WalletID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Stocks_StockID",
                        column: x => x.StockID,
                        principalTable: "Stocks",
                        principalColumn: "StockID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Wallets_WalletID",
                        column: x => x.WalletID,
                        principalTable: "Wallets",
                        principalColumn: "WalletID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    StockID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceID);
                    table.ForeignKey(
                        name: "FK_Prices_Stocks_StockID",
                        column: x => x.StockID,
                        principalTable: "Stocks",
                        principalColumn: "StockID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    StopID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gain1 = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    Gain2 = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    Loss = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    ExclusionDate = table.Column<DateTime>(nullable: true),
                    StockID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.StopID);
                    table.ForeignKey(
                        name: "FK_Stops_Stocks_StockID",
                        column: x => x.StockID,
                        principalTable: "Stocks",
                        principalColumn: "StockID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StockID",
                table: "Orders",
                column: "StockID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WalletID",
                table: "Orders",
                column: "WalletID");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_StockID",
                table: "Prices",
                column: "StockID");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_SubSectorID",
                table: "Stocks",
                column: "SubSectorID");

            migrationBuilder.CreateIndex(
                name: "IX_Stops_StockID",
                table: "Stops",
                column: "StockID");

            migrationBuilder.CreateIndex(
                name: "IX_SubSectors_SectorID",
                table: "SubSectors",
                column: "SectorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "SubSectors");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}

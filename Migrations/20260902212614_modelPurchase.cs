using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RelationsNaN.Migrations
{
    /// <inheritdoc />
    public partial class modelPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Platform_platformsId",
                table: "GamePlatform");

            migrationBuilder.RenameColumn(
                name: "platformsId",
                table: "GamePlatform",
                newName: "PlatformsId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlatform_platformsId",
                table: "GamePlatform",
                newName: "IX_GamePlatform_PlatformsId");

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamePurchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePurchase_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePurchase_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePurchase_GameId",
                table: "GamePurchase",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePurchase_PurchaseId",
                table: "GamePurchase",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlatform_Platform_PlatformsId",
                table: "GamePlatform",
                column: "PlatformsId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlatform_Platform_PlatformsId",
                table: "GamePlatform");

            migrationBuilder.DropTable(
                name: "GamePurchase");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.RenameColumn(
                name: "PlatformsId",
                table: "GamePlatform",
                newName: "platformsId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlatform_PlatformsId",
                table: "GamePlatform",
                newName: "IX_GamePlatform_platformsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlatform_Platform_platformsId",
                table: "GamePlatform",
                column: "platformsId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

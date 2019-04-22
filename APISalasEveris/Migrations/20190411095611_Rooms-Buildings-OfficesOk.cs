using Microsoft.EntityFrameworkCore.Migrations;

namespace APISalasEveris.Migrations
{
    public partial class RoomsBuildingsOfficesOk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Office_idOffice",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomInformations_Building_idBuilding",
                table: "RoomInformations");

            migrationBuilder.DropIndex(
                name: "IX_RoomInformations_idBuilding",
                table: "RoomInformations");

            migrationBuilder.DropIndex(
                name: "IX_Building_idOffice",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "idBuilding",
                table: "RoomInformations");

            migrationBuilder.DropColumn(
                name: "idOffice",
                table: "Building");

            migrationBuilder.CreateIndex(
                name: "IX_RoomInformations_BuildingId",
                table: "RoomInformations",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_OfficeId",
                table: "Building",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Office_OfficeId",
                table: "Building",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomInformations_Building_BuildingId",
                table: "RoomInformations",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Office_OfficeId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomInformations_Building_BuildingId",
                table: "RoomInformations");

            migrationBuilder.DropIndex(
                name: "IX_RoomInformations_BuildingId",
                table: "RoomInformations");

            migrationBuilder.DropIndex(
                name: "IX_Building_OfficeId",
                table: "Building");

            migrationBuilder.AddColumn<int>(
                name: "idBuilding",
                table: "RoomInformations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idOffice",
                table: "Building",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomInformations_idBuilding",
                table: "RoomInformations",
                column: "idBuilding");

            migrationBuilder.CreateIndex(
                name: "IX_Building_idOffice",
                table: "Building",
                column: "idOffice");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Office_idOffice",
                table: "Building",
                column: "idOffice",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomInformations_Building_idBuilding",
                table: "RoomInformations",
                column: "idBuilding",
                principalTable: "Building",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

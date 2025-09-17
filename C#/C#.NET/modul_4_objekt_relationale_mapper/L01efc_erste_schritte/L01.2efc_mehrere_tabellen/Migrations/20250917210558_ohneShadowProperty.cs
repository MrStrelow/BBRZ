using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L01._2efc_mehrere_tabellen.Migrations
{
    /// <inheritdoc />
    public partial class ohneShadowProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreparationSteps_Dishes_MoreDishId",
                table: "PreparationSteps");

            migrationBuilder.RenameColumn(
                name: "MoreDishId",
                table: "PreparationSteps",
                newName: "EinSehrKomischerNameFuerDenFremdschluessel");

            migrationBuilder.RenameIndex(
                name: "IX_PreparationSteps_MoreDishId",
                table: "PreparationSteps",
                newName: "IX_PreparationSteps_EinSehrKomischerNameFuerDenFremdschluessel");

            migrationBuilder.AddForeignKey(
                name: "FK_PreparationSteps_Dishes_EinSehrKomischerNameFuerDenFremdschluessel",
                table: "PreparationSteps",
                column: "EinSehrKomischerNameFuerDenFremdschluessel",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreparationSteps_Dishes_EinSehrKomischerNameFuerDenFremdschluessel",
                table: "PreparationSteps");

            migrationBuilder.RenameColumn(
                name: "EinSehrKomischerNameFuerDenFremdschluessel",
                table: "PreparationSteps",
                newName: "MoreDishId");

            migrationBuilder.RenameIndex(
                name: "IX_PreparationSteps_EinSehrKomischerNameFuerDenFremdschluessel",
                table: "PreparationSteps",
                newName: "IX_PreparationSteps_MoreDishId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreparationSteps_Dishes_MoreDishId",
                table: "PreparationSteps",
                column: "MoreDishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

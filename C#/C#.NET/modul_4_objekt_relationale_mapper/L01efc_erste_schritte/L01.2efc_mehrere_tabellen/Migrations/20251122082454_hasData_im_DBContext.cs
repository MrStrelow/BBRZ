using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace L01._2efc_mehrere_tabellen.Migrations
{
    /// <inheritdoc />
    public partial class hasData_im_DBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Ein einfaches Spiegelei mit Salz.", "Spiegelei", 0m },
                    { 2, "Ein süßer Klassiker.", "Pfannkuchen", 0m }
                });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Unit" },
                values: new object[] { "Eier", "Stück" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Mehl");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Unit" },
                values: new object[] { "Zucker", "g" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Unit" },
                values: new object[,]
                {
                    { 4, "Milch", "ml" },
                    { 5, "Salz", "Prise" }
                });

            migrationBuilder.InsertData(
                table: "DishIngredient",
                columns: new[] { "IngredientsId", "MoreDishesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "PreparationSteps",
                columns: new[] { "Id", "Instruction", "MoreDishId", "StepNumber" },
                values: new object[,]
                {
                    { 1, "Pfanne erhitzen.", 1, 1 },
                    { 2, "Ei in die Pfanne schlagen.", 1, 2 },
                    { 3, "Mit Salz würzen.", 1, 3 },
                    { 4, "Mehl, Zucker, Milch und Eier zu einem Teig verrühren.", 2, 1 },
                    { 5, "Etwas Teig in eine heiße Pfanne geben.", 2, 2 },
                    { 6, "Von beiden Seiten goldbraun backen.", 2, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PreparationSteps_Dishes_MoreDishId",
                table: "PreparationSteps",
                column: "MoreDishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreparationSteps_Dishes_MoreDishId",
                table: "PreparationSteps");

            migrationBuilder.DeleteData(
                table: "DishIngredient",
                keyColumns: new[] { "IngredientsId", "MoreDishesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DishIngredient",
                keyColumns: new[] { "IngredientsId", "MoreDishesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DishIngredient",
                keyColumns: new[] { "IngredientsId", "MoreDishesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DishIngredient",
                keyColumns: new[] { "IngredientsId", "MoreDishesId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "DishIngredient",
                keyColumns: new[] { "IngredientsId", "MoreDishesId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "DishIngredient",
                keyColumns: new[] { "IngredientsId", "MoreDishesId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "PreparationSteps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PreparationSteps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PreparationSteps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PreparationSteps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PreparationSteps",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PreparationSteps",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "MoreDishId",
                table: "PreparationSteps",
                newName: "EinSehrKomischerNameFuerDenFremdschluessel");

            migrationBuilder.RenameIndex(
                name: "IX_PreparationSteps_MoreDishId",
                table: "PreparationSteps",
                newName: "IX_PreparationSteps_EinSehrKomischerNameFuerDenFremdschluessel");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Unit" },
                values: new object[] { "Mehl", "g" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Zucker");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Unit" },
                values: new object[] { "Ei", "Stück" });

            migrationBuilder.AddForeignKey(
                name: "FK_PreparationSteps_Dishes_EinSehrKomischerNameFuerDenFremdschluessel",
                table: "PreparationSteps",
                column: "EinSehrKomischerNameFuerDenFremdschluessel",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aufgabe_2.Migrations
{
    /// <inheritdoc />
    public partial class complex_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Visits_VisitId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Visits_VisitId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Tables_TableId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Bills_VisitId",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "Visits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TakeAwayId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "Bills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TakeAwayId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TakeAways",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickupTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeAways", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakeAways_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                unique: true,
                filter: "[DeliveryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TakeAwayId",
                table: "Orders",
                column: "TakeAwayId",
                unique: true,
                filter: "[TakeAwayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_DeliveryId",
                table: "Bills",
                column: "DeliveryId",
                unique: true,
                filter: "[DeliveryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_TakeAwayId",
                table: "Bills",
                column: "TakeAwayId",
                unique: true,
                filter: "[TakeAwayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_VisitId",
                table: "Bills",
                column: "VisitId",
                unique: true,
                filter: "[VisitId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_CustomerId",
                table: "Deliveries",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TakeAways_CustomerId",
                table: "TakeAways",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Deliveries_DeliveryId",
                table: "Bills",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_TakeAways_TakeAwayId",
                table: "Bills",
                column: "TakeAwayId",
                principalTable: "TakeAways",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Visits_VisitId",
                table: "Bills",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveries_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TakeAways_TakeAwayId",
                table: "Orders",
                column: "TakeAwayId",
                principalTable: "TakeAways",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Visits_VisitId",
                table: "Orders",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Tables_TableId",
                table: "Visits",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Deliveries_DeliveryId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_TakeAways_TakeAwayId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Visits_VisitId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveries_DeliveryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TakeAways_TakeAwayId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Visits_VisitId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Tables_TableId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "TakeAways");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TakeAwayId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Bills_DeliveryId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_TakeAwayId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_VisitId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TakeAwayId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "TakeAwayId",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_VisitId",
                table: "Bills",
                column: "VisitId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Visits_VisitId",
                table: "Bills",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Visits_VisitId",
                table: "Orders",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Tables_TableId",
                table: "Visits",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

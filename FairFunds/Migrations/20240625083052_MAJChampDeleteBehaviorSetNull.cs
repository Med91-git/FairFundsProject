using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairFunds.Migrations
{
    /// <inheritdoc />
    public partial class MAJChampDeleteBehaviorSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_Categories_CategoryID",
                table: "Expenditures");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Expenditures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_Categories_CategoryID",
                table: "Expenditures",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_Categories_CategoryID",
                table: "Expenditures");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Expenditures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_Categories_CategoryID",
                table: "Expenditures",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairFunds.Migrations
{
    /// <inheritdoc />
    public partial class SuppressionAnnotationSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_Categories_CategoryID",
                table: "Expenditures");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_Categories_CategoryID",
                table: "Expenditures",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_Categories_CategoryID",
                table: "Expenditures");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_Categories_CategoryID",
                table: "Expenditures",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}

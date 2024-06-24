using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairFunds.Migrations
{
    /// <inheritdoc />
    public partial class MAJTableDepense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "customuserId",
                table: "Expenditures",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_CategoryID",
                table: "Expenditures",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_customuserId",
                table: "Expenditures",
                column: "customuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_AspNetUsers_customuserId",
                table: "Expenditures",
                column: "customuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Expenditures_AspNetUsers_customuserId",
                table: "Expenditures");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_Categories_CategoryID",
                table: "Expenditures");

            migrationBuilder.DropIndex(
                name: "IX_Expenditures_CategoryID",
                table: "Expenditures");

            migrationBuilder.DropIndex(
                name: "IX_Expenditures_customuserId",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "customuserId",
                table: "Expenditures");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TipsyTasty.Data.Migrations
{
    public partial class CreateNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Categories_CategoryId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Collections");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CategoryId",
                table: "Brands",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                table: "Brands",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CategoryId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Brands");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Categories_CategoryId",
                table: "Collections",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

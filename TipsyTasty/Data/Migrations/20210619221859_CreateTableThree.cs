using Microsoft.EntityFrameworkCore.Migrations;

namespace TipsyTasty.Data.Migrations
{
    public partial class CreateTableThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Collections_CollectionId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CategoryId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CollectionId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AverageNotes",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "AveragePrice",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Brands",
                newName: "AgeStatment");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_BrandId",
                table: "Collections",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Brands_BrandId",
                table: "Collections",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Categories_CategoryId",
                table: "Collections",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Brands_BrandId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Categories_CategoryId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_BrandId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Collections");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AgeStatment",
                table: "Brands",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AverageNotes",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AveragePrice",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AverageRating",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CategoryId",
                table: "Brands",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CollectionId",
                table: "Brands",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                table: "Brands",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Collections_CollectionId",
                table: "Brands",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

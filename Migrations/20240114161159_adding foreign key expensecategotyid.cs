using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagement2.Migrations
{
    /// <inheritdoc />
    public partial class addingforeignkeyexpensecategotyid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseCategotyId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseCategotyId",
                table: "Expenses",
                column: "ExpenseCategotyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpsenseCategories_ExpenseCategotyId",
                table: "Expenses",
                column: "ExpenseCategotyId",
                principalTable: "ExpsenseCategories",
                principalColumn: "ExpenseCategotyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpsenseCategories_ExpenseCategotyId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseCategotyId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseCategotyId",
                table: "Expenses");
        }
    }
}

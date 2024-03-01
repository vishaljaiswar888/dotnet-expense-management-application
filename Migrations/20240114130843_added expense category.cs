using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagement2.Migrations
{
    /// <inheritdoc />
    public partial class addedexpensecategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpsenseCategories",
                columns: table => new
                {
                    ExpenseCategotyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseCategotyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpsenseCategories", x => x.ExpenseCategotyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpsenseCategories");
        }
    }
}

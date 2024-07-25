using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace budget.Repo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransactionsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Categories_CategoryID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Transactions",
                newName: "TransactionCategoryCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CategoryID",
                table: "Transactions",
                newName: "IX_Transactions_TransactionCategoryCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Categories_TransactionCategoryCategoryID",
                table: "Transactions",
                column: "TransactionCategoryCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Categories_TransactionCategoryCategoryID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionCategoryCategoryID",
                table: "Transactions",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TransactionCategoryCategoryID",
                table: "Transactions",
                newName: "IX_Transactions_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Categories_CategoryID",
                table: "Transactions",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

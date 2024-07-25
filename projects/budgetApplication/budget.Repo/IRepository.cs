using budget.Models;

namespace budget.Repo
{
    public interface IRepository
    {
        // Load Transactions
        List<Transaction> LoadAllTransactions();

        // Load Transaction By ID
        Transaction GetTransactionById( int id );

        // Load Transactions By Name
        List<Transaction> GetTransactionsByName( string name );

        // Load Transactions By Category
        List<Transaction> GetTransactionsByCategory( Category category );

        // Save Transaction
        void SaveTransaction( Transaction transaction );

        // Delete Transaction
        void DeleteTransaction( Transaction transaction );

        // Update Transaction
        void UpdateTransaction( Transaction transaction );

        // Load Categories
        List<Category> LoadAllCategories();

        // Load Category By ID
        Category? GetCategoryById( int id );

        // Load Category By Name
        Category? GetCategoryByName( string name );

        // Load Matching Categories
        List<Category> GetCategoriesByName( string name );

        // Save Category
        void SaveCategory( Category category );

        // Load Spending
        decimal GetSpending();

        // Load Spending by Category
        Dictionary<string, decimal> GetSpendingByCategory();

    }

}
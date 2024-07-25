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
        List<Transaction> GetTransactionByName( string name );

        // Save Transaction
        void SaveTransaction( Transaction transaction );

        // Load Categories
        List<Category> LoadAllCategories();

        // Load Category By ID
        Category? GetCategoryById( int id );

    //     // Load Category By Name
    //     Category GetCategoryByName( string name );

        // Save Category
        void SaveCategory( Category category );

        // Load Spending
        decimal GetSpending();

        // Load Spending by Category
        Dictionary<string, decimal> GetSpendingByCategory();

    }

}
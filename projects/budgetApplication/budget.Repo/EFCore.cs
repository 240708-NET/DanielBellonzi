using System;
using System.Data;
using System.Linq;
using budget.Models;
using Microsoft.EntityFrameworkCore;

namespace budget.Repo
{

    public class EFCore : IRepository
    {
        // static readonly string connectionstring = File.ReadAllText("./..connectionstring");
        BudgetContext context;

        public EFCore()
        {     
            context = new BudgetContext();
            // DbContextOptions<BudgetContext> options;
            // options = new DbContextOptionsBuilder<BudgetContext>()
            //     .UseSqlServer(connectionstring)
            //     .Options;
            // context = new BudgetContext(options);
        }

        // Load Transactions
        public List<Transaction> LoadAllTransactions()
        {
            return context.Transactions.ToList();
        }

        // Load Transaction By ID
        public Transaction GetTransactionById( int id )
        {
            Transaction transaction = context.Transactions.Find(id);
            return transaction;
        }

        // Load Transactions By Name
        public List<Transaction> GetTransactionsByName( string name )
        {
            name = name.ToLower();
            var transactions = from t in context.Transactions.ToList()
                where t.TransactionName.ToLower().Contains(name)
                select t;
            return ( List<Transaction> ) transactions.ToList();
        }

        public List<Transaction> GetTransactionsByCategory( Category category )
        {
            var transactions = context.Transactions.Where( t => t.TransactionCategory == category ).ToList();
            return ( List<Transaction> ) transactions;
        }

        // Save Transaction
        public void SaveTransaction( Transaction transaction )
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();
        }

        // Delete Transaction
        public void DeleteTransaction ( Transaction transaction )
        {
            context.Transactions.Remove(transaction);
        }

        // Update Transaction
        public void UpdateTransaction( Transaction transaction )
        {
            Transaction oldTransaction = GetTransactionById( transaction.TransactionID );

            if ( oldTransaction != null )
            {
                oldTransaction.TransactionName = transaction.TransactionName;
                oldTransaction.TransactionDate = transaction.TransactionDate;
                oldTransaction.TransactionAmount = transaction.TransactionAmount;
                oldTransaction.TransactionCategory = transaction.TransactionCategory;

                context.SaveChanges();
            }
        }

        // Load Categories
        public List<Category> LoadAllCategories()
        {
            return context.Categories.ToList();
        }

        // Load Category By ID
        public Category? GetCategoryById( int id )
        {
            Category? category = context.Categories.Find(id);
            return category;
        }

        // Load Category By Name
        public Category? GetCategoryByName( string name )
        {
            var category = context.Categories.Where( c => c.CategoryName == name).ToList();
            return (Category) (category.Count != 0 ? category[0] : null);
        }

        // Load Categories By Name
        public List<Category> GetCategoriesByName( string name )
        {
            name = name.ToLower();
            var categories = from c in context.Categories.ToList()
                where c.CategoryName.ToLower().Contains(name)
                select c;
            return ( List<Category> ) categories.ToList();
        }

        // Save Category
        public void SaveCategory( Category category )
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        // Load Spending
        public decimal GetSpending()
        {
            decimal total = 0;
            List<Transaction> transactions = LoadAllTransactions();
            foreach ( Transaction t in transactions)
            {
                total += t.TransactionAmount;
            }
            return total;
        }

        // Load Spending by Category
        public Dictionary<string, decimal> GetSpendingByCategory()
        {
            Dictionary<string, decimal> spendingList = new Dictionary<string, decimal>();
            List<Transaction> transactions = LoadAllTransactions();
            Console.WriteLine(transactions.Count);
            foreach ( Transaction t in transactions )
            {
                // Console.WriteLine("check");
                // Console.WriteLine( t.TransactionCategory.ToString() );
                Console.WriteLine( t );
                // if ( !spendingList.ContainsKey(t.TransactionCategory.CategoryName) )
                // {
                //     spendingList.Add(t.TransactionCategory.CategoryName, t.TransactionAmount);
                // }
                // else
                // {
                //     spendingList[t.TransactionCategory.CategoryName] += t.TransactionAmount;
                // }
                if ( !spendingList.ContainsKey(t.TransactionName) )
                {
                    spendingList.Add(t.TransactionName, t.TransactionAmount);
                }
                else
                {
                    spendingList[t.TransactionName] += t.TransactionAmount;
                }

            }

            return spendingList;
        }
    }
}
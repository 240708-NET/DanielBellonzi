using System;
using System.Data;
using System.Linq;
using budget.Models;
using Microsoft.EntityFrameworkCore;

namespace budget.Repo
{

    public class EFCore : IRepository
    {
        static readonly string connectionstring = File.ReadAllText("./..connectionstring");
        static BudgetContext context;

        public EFCore( string CS )
        {
            
            DbContextOptions<BudgetContext> options;
            options = new DbContextOptionsBuilder<BudgetContext>()
                .UseSqlServer(connectionstring)
                .Options;
            context = new BudgetContext(options);
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
        public List<Transaction> GetTransactionByName( string name )
        {
            name = name.ToLower();
            var transactions = from t in context.Transactions.ToList()
                where t.TransactionName.ToLower().Contains(name)
                select t;
            return ( List<Transaction> )transactions;
        }

        // Save Transaction
        public void SaveTransaction( Transaction transaction )
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();
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
        public Category GetCategoryByName( string name )
        {
            return new Category();
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
            foreach ( Transaction t in transactions )
            {
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
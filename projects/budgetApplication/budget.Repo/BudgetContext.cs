using System;
using Microsoft.EntityFrameworkCore;
using budget.Models;

namespace budget.Repo
{
    public class BudgetContext : DbContext
    {
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Category> Categories => Set<Category>();

        // public BudgetContext( DbContextOptions<BudgetContext> options) : base( options ){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = File.ReadAllText( "./../connectionstring" );
            optionsBuilder.UseSqlServer(ConnectionString);
        }

    }



}

using System.ComponentModel.DataAnnotations;
namespace budget.Models
{

    public class Transaction
    {

        [Key]
        public int TransactionID { get; set; }
        public string TransactionName { get; set; }
        public DateOnly TransactionDate { get; set; }
        public decimal TransactionAmount { get; set;}
        public Category TransactionCategory { get; set; }

        public Transaction( string tName, decimal tAmount, DateOnly tDate, Category tCategory )
        {

            this.TransactionName = tName;
            this.TransactionAmount = tAmount;
            this.TransactionDate = tDate;
            this.TransactionCategory = tCategory;

        }

        public Transaction() {}

        public override string ToString()
        {
            Console.WriteLine( $"category is null {(TransactionCategory == null)}");
            return $"{TransactionName}: {TransactionCategory}";
        }
        
    }
}
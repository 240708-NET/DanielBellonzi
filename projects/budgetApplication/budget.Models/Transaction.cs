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
        public Category category { get; set; }
    }
}
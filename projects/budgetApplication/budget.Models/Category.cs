using System.ComponentModel.DataAnnotation;

namespace budget.Models
{
    public class Category
    {

        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

}
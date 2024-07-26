﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace budget.Models
{
    [Index(nameof(CategoryName), IsUnique = true)]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public Category( string cName )
        {
            this.CategoryName = cName;
        }

        public Category() {}

        public override string ToString()
        {
            return $"Category {this.CategoryID}: {this.CategoryName}";
        }

    }

}
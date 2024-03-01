using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement2.Models
{
    public class ExpenseCategoryEntity
    {
        [Key]
        public int ExpenseCategotyId { get; set; }
        public string ExpenseCategotyName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement2.Models
{
    public class ExpenseEntity
    {
        [Key]
        public int ExpenseId { get; set; }



        [Required(ErrorMessage = "Please select a expense date!")]
        [DataType(DataType.Date)]
        [Display(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }



        [Required(ErrorMessage = "Please enter this detail!")]
        [MinLength(3, ErrorMessage = "Name is too short...")]
        [Display(Name = "Paid To")]
        public string ExpenseGivenTo { get; set; }



        [Required(ErrorMessage = "Please enter this detail!")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid amount...")]
        [Display(Name = "Expense Amount")]
        public double ExpenseAmount { get; set; }




        // Foreign Key
        [Display(Name = "Expense Category")]

        public int ExpenseCategotyId { get; set; }

        [ForeignKey("ExpenseCategotyId")]
        public virtual ExpenseCategoryEntity? ExpenseCategory { get; set; }
    }
}

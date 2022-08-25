using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagement.Models
{
    public class DailyExpense
    {
        public int Id { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }

        [Display(Name = "Expense Date")]
        [Required(ErrorMessage = "Please Enter Expense Date")]
        public string ExpenseDate { get; set; }

        [Display(Name = "Total Amount")]
        [Required(ErrorMessage = "Please Enter Total Amount")]
        public string TotalAmount { get; set; }

       
    }
}
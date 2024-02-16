using System.ComponentModel.DataAnnotations.Schema;

namespace ExepnseTrackerAPI.Models.Domains
{
    [Table("tbl_ExpenseCategory")]
    public class TblExpenseCategory
    {
        public int CategoryID { get; set; } 

        public string? CategoryName { get; set; }

        public DateTime? CreatedOn { get; set; }

       //public virtual ICollection<TblExpenseLists>? TblExpenseLists { get; set; }
    }
}

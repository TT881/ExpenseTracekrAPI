using System.ComponentModel.DataAnnotations.Schema;

namespace ExepnseTrackerAPI.Models.Domains
{
    [Table("tbl_ExpenseLists")]
    public class TblExpenseLists
    {
        public int ExpenseID { get; set; }

        public int UserID { get; set; }   //Fk 

        public int CategoryID { get; set; }  //Fk 

        public decimal Amount { get; set; }  

        public string? Remarks {  get; set; }   

        public DateTime ExpenseDate { get; set; }

       // public virtual TblUser TblUser { get; set; } = null!;

       // public virtual TblExpenseCategory TblExpenseCategory { get; set;} = null!;
    }
}

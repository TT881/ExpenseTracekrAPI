using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExepnseTrackerAPI.Models.Domains
{
    [Table("tbl_ExpenseLists")]
    public class TblExpenseLists
    {
        
        public int ExpenseID { get; set; }

        [ForeignKey("TblUser")] // This attribute is optional if you follow EF conventions
        public int UserID { get; set; }   // FK 

        [ForeignKey("TblExpenseCategory")] // This attribute is optional if you follow EF conventions
        public int CategoryID { get; set; }  // FK 

        public decimal Amount { get; set; }

        public string? Remarks { get; set; }

        public DateTime ExpenseDate { get; set; }

        [JsonIgnore]
        public virtual TblUser TblUser { get; set; } = null!;

        [JsonIgnore]
        public virtual TblExpenseCategory TblExpenseCategory { get; set; } = null!; 
    }

}

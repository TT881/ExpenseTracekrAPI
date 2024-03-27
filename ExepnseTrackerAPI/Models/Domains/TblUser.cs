using System.ComponentModel.DataAnnotations.Schema;

namespace ExepnseTrackerAPI.Models.Domains
{
    [Table("tbl_User")]
    public class TblUser
    {
        public TblUser()
        {
            TblExpenseLists = new HashSet<TblExpenseLists>();
        }
        public int UserId { get; set; } 
        public string? Name { get; set; }

        public string? Password {  get; set; }  

        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<TblExpenseLists> TblExpenseLists { get; set; }

    }
}

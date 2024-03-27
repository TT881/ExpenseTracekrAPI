using System.ComponentModel.DataAnnotations.Schema;

namespace ExepnseTrackerAPI.Models.Domains
{
    [Table("tbl_UITableConfig")]
    public class TblUITableConfig
    {
        public TblUITableConfig() { }   
        public int UITableID { get; set; }  

        public string? TableName {  get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty; 

        public DateTime? CreatedOn { get; set; } 

        public string? CreatedBy { get; set; } = string.Empty;

        public virtual ICollection<TblUIColumnConfig>? TblUIColumnConfigs { get; set; }
    }
}

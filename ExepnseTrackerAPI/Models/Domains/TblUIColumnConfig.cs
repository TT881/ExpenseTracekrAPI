using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExepnseTrackerAPI.Models.Domains
{
    [Table("tbl_UIColumnConfig")]
    public class TblUIColumnConfig
    {
      
        public int ColumnID { get; set; }

        [ForeignKey("TblUITableConfig")]
        public int UITableID { get; set; }  

        public string? ColumnName { get; set; } = string.Empty;

        public string? Remarks { get; set; } = string.Empty;

        public bool? Visible { get; set; } 

        public int? Width { get; set; }  

        public string? DisplayName { get; set; } = string.Empty; 

        public string? Align { get; set; } = string.Empty;   

        public string? UIelement { get; set; } = string.Empty;

        public string? CreatedBy { get; set; } = string.Empty; 

        public DateTime? CreatedOn { get; set; }

        public int? Sort {  get; set; }

        [JsonIgnore]
        public virtual TblUITableConfig TblUITableConfig { get; set; } = null!;
    }

}

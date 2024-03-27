using ExepnseTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog; 

namespace ExepnseTrackerAPI.Services
{
    public class ClsUIColumnConfig : ControllerBase
    {
        private readonly ExpenseDbContext _dbContext;  

        public ClsUIColumnConfig(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public string GetUIColumns(int tableID)
        {
            try
            {
                var query = (from col in _dbContext.TblUIColumnConfig
                             where col.Visible == true && col.UITableID == tableID
                             select col).ToList();

                if (query.Any())
                {
                    return JsonConvert.SerializeObject(query, Formatting.Indented);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
                return string.Empty;
            }
        }

    }
}

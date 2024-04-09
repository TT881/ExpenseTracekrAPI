using ExepnseTrackerAPI.Models;
using ExepnseTrackerAPI.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Serilog; 

namespace ExepnseTrackerAPI.Services
{
    public class ExpenseService : ControllerBase
    {
        private readonly ExpenseDbContext _dbContext;

        public ExpenseService(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IActionResult AddExpense([FromBody] ExpenseList explist)
        {
            try
            {
                var count = 0;
                _dbContext.TblExpenseLists.Add(new TblExpenseLists
                {
                   CategoryID  = int.Parse(explist.category),
                   Remarks = explist.Remark, 
                   Amount = explist.Cost, 
                   ExpenseDate = DateTime.Parse(explist.date), 
                   UserID = int.Parse(explist.UserID), 
                });

                count = _dbContext.SaveChanges();
                if (count > 0)
                {
                    return Ok(explist);
                }
                return Ok(explist); 
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public string GetExpenseCategory()
        {
            try
            {
                var query = (from category in _dbContext.TblExpenseCategory
                             select new
                             {
                                 id = category.CategoryID,
                                 name = category.CategoryName
                             }).ToList();

                return JsonConvert.SerializeObject(query, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string? GetExpenseListbyDate(DateTime date , int userID)
        {
            try
            {
                var query = (from ex in _dbContext.TblExpenseLists
                             join cat in _dbContext.TblExpenseCategory on
                             ex.CategoryID equals cat.CategoryID
                             where ex.ExpenseDate == date && ex.UserID == userID
                             select new
                             {
                                 Category = cat.CategoryName,
                                 Cost = ex.Amount,
                                 Date = ex.ExpenseDate,
                             }).ToList(); 
                if(query.Count > 0)
                {
                    return JsonConvert.SerializeObject(query, Formatting.Indented);
                }
                else
                {
                    return null; 
                }  
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return ex.Message; 
            }
        }
    }
 
}

public class ExpenseList 
{ 
    public int Cost { get; set; }

    public string? Remark { get; set; }  = String.Empty;

    public string category { get; set; } = String.Empty; 

    public string date { get; set; }  

    public string UserID { get; set; } 

}

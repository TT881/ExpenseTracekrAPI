using ExepnseTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExepnseTrackerAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase 
    {
        private readonly ExpenseService _expCtrl; 

        public ExpenseController(ExpenseService expCtrl)
        {
            _expCtrl = expCtrl;
        }

        [HttpPost("AddExpense")]
        public IActionResult AddExpense([FromBody] ExpenseList expList)
        {
            return _expCtrl.AddExpense(expList);
        }

        [HttpGet("GetExpenseCategory")]
        public string GetExpenseCategory()
        {
            return _expCtrl.GetExpenseCategory();
        } 

    }
}

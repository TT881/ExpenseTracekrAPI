using ExepnseTrackerAPI.Models;
using ExepnseTrackerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExepnseTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UIConfigController : ControllerBase
    {

        private readonly ClsUIColumnConfig _clsColConfig;
        public UIConfigController(ClsUIColumnConfig clsColConfig)
        {
            _clsColConfig = clsColConfig;
        }

        [HttpGet("GetUIColumnConfig")]
        public string GetUIColumnConfig(int tableId)
        {
            try
            {
                return _clsColConfig.GetUIColumns(tableId); 

            }  catch(Exception ex)
            {
                return ex.Message.ToString(); 
            } 
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APICall.Controllers
{
    public class DataController : Controller
    {
        // Sample action to retrieve data
        public IActionResult GetData()
        {
            // Sample data (replace with actual data retrieval logic)
            var data = new List<object>
            {
                new { Id = 1, Name = "Record 1", Value = 100 },
                new { Id = 2, Name = "Record 2", Value = 200 },
                // Add more records as needed
            };

            return Json(data);
        }
    }
}


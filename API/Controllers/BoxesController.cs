using System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class BoxesController : ControllerBase
    {
        [HttpGet]
        public string GetBoxes()
        {
            return "This will be a list of boxes";
        }

        [HttpGet("{id}")]
        public string GetBox(Guid id)
        {
            return "Single box";
        }
    }
}

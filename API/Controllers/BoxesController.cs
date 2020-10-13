using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class BoxesController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        public BoxesController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<Box>>> GetBoxes()
        {
            var boxes = await unitOfWork._BoxRepo.GetBoxesAsync();

            return Ok(boxes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Box>> GetBox(int id)
        {
            return await unitOfWork._BoxRepo.GetBoxByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Box>> PostBox(Box box)
        {
            await unitOfWork._BoxRepo.PostBox(box);
            return CreatedAtAction("GetBoxes", new { id = box.Id }, box); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Box>> Delete(int id)
        {
            var box = await unitOfWork._BoxRepo.DeleteBox(id);
            if (box == null)
            {
                return NotFound();
            }
            return box;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Box box)
        {
            if (id != box.Id)
            {
                return BadRequest();
            }
            await unitOfWork._BoxRepo.PutBox(box);
            return NoContent();
        }
    }
}

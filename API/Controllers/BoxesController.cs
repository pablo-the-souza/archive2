using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class BoxesController : ControllerBase
    {
        private readonly IBoxRepository _repo;
        public BoxesController(IBoxRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Box>>> GetBoxes()
        {
            var boxes = await _repo.GetBoxesAsync();

            return Ok(boxes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Box>> GetBox(int id)
        {
            return await _repo.GetBoxByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Box>> PostBox(Box box)
        {
            await _repo.PostBox(box);
            return CreatedAtAction("GetBoxes", new { id = box.Id }, box); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Box>> Delete(int id)
        {
            var box = await _repo.DeleteBox(id);
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
            await _repo.PutBox(box);
            return NoContent();
        }
    }
}

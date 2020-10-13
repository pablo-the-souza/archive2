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
    public class PoliciesController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        public PoliciesController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<Policy>>> GetPolicies()
        {
            var Policies = await unitOfWork._PolicyRepo.GetPoliciesAsync();

            return Ok(Policies);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            return await unitOfWork._PolicyRepo.GetPolicyByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(Policy policy)
        {
            await unitOfWork._PolicyRepo.PostPolicy(policy);
            return CreatedAtAction("GetPolicies", new { id = policy.Id }, policy); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Policy>> Delete(int id)
        {
            var policy = await unitOfWork._PolicyRepo.DeletePolicy(id);
            if (policy == null)
            {
                return NotFound();
            }
            return policy;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Policy policy)
        {
            if (id !=policy.Id)
            {
                return BadRequest();
            }
            await unitOfWork._PolicyRepo.PutPolicy(policy);
            return NoContent();
        }
    }
}


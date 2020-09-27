using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyRepository _repo;
        public PoliciesController(IPolicyRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Policy>>> GetPolicies()
        {
            var Policies = await _repo.GetPoliciesAsync();

            return Ok(Policies);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            return await _repo.GetPolicyByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(Policy policy)
        {
            await _repo.PostPolicy(policy);
            return CreatedAtAction("GetPolicies", new { id = policy.Id }, policy); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Policy>> Delete(int id)
        {
            var policy = await _repo.DeletePolicy(id);
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
            await _repo.PutPolicy(policy);
            return NoContent();
        }
    }
}


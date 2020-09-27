using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class PolicyRepository : IPolicyRepository
{
    private readonly ArchiveContext _context;
    public PolicyRepository(ArchiveContext context)
    {
        _context = context;
    }

    public async Task<Policy> GetPolicyByIdAsync(int id)
    {
        return await _context.Policies
        .Include(p => p.Box)
        .FirstOrDefaultAsync(p => p.Id == id);; //doesn't allow iqueriable 
    }

    public async Task<IReadOnlyList<Policy>> GetPoliciesAsync()
    {
        return await _context.Policies // point where our query is sent to sequel
        .Include(p => p.Box)
        .ToListAsync();
    }

    public async Task<Policy> PostPolicy(Policy policy)
    {
        _context.Set<Policy>().Add(policy);
        await _context.SaveChangesAsync();
        return policy;
    }

    public async Task<Policy> DeletePolicy(int id)
    {
        var entity = await _context.Set<Policy>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        _context.Set<Policy>().Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Policy> PutPolicy(Policy policy)
        {
            _context.Entry(policy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return policy;
        }
}

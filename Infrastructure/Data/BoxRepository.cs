using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class BoxRepository : IBoxRepository
{
    private readonly ArchiveContext _context;
    public BoxRepository(ArchiveContext context)
    {
        _context = context;
    }

    public async Task<Box> GetBoxByIdAsync(int id)
    {
        return await _context.Boxes
        .Include(b => b.Policies)
        .FirstOrDefaultAsync(p => p.Id == id); ;

    }

    public async Task<IReadOnlyList<Box>> GetBoxesAsync()
    {
        return await _context.Boxes
        .Include(b => b.Policies)
        .ToListAsync();
    }

    public async Task<Box> PostBox(Box box)
    {
        _context.Set<Box>().Add(box);
        await _context.SaveChangesAsync();
        return box;
    }

    public async Task<Box> DeleteBox(int id)
    {
        var entity = await _context.Set<Box>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        _context.Set<Box>().Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Box> PutBox(Box box)
    {
        _context.Entry(box).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return box;
    }
}

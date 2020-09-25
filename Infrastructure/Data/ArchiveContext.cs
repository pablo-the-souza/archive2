using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
public class ArchiveContext : DbContext
{
public ArchiveContext(DbContextOptions<ArchiveContext> options) : base(options)
{
}

public DbSet<Box> Boxes {get; set;}
}
}
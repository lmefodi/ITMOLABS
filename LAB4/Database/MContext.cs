using LizaLab4.Model;
using Microsoft.EntityFrameworkCore;

namespace LizaLab4.Database;

public class MContext:DbContext
{
    public DbSet<Track>? Tracks { get; set; }
    
    public MContext(DbContextOptions<MContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}

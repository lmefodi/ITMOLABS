using LizaLab3.Model;
using Microsoft.EntityFrameworkCore;

namespace LizaLab3.Database;

public class MContext:DbContext
{
    public DbSet<Track>? Tracks { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MusicalCatalogue.db");
    }
}

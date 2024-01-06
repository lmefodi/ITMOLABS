using LizaLab5.Models;
using Microsoft.EntityFrameworkCore;

namespace LizaLab5.Database;

public class MyContext : DbContext
{
    public DbSet<MusicTrack>? Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Tracks.db");
    }
}

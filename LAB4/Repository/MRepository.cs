using LizaLab4.Model;
using LizaLab4.Database;
using Microsoft.EntityFrameworkCore;

namespace LizaLab4.Repository;

public class MRepository(MContext context) : IMRepository
{
    public Task Add(Track track)
    {
        if (!context.Tracks!.Any(t => t.Name == track.Name && t.Author == track.Author))
        {
            context.Tracks?.Add(track);
            return context.SaveChangesAsync();
        }

        throw new Exception("Трек уже существует.");
    }

    public Task<List<Track>> Search(string keyword, int mode)
    {
        return mode switch
        {
            1 => context.Tracks!.Where(t => t.Name.ToLower() == keyword.ToLower()).ToListAsync(),
            2 => context.Tracks!.Where(t => t.Author.ToLower() == keyword.ToLower()).ToListAsync(),
            3 => context.Tracks!.Where(t => t.Name.ToLower() == keyword.ToLower() || t.Author.ToLower() ==
                keyword.ToLower()).ToListAsync(),
            _ => throw new Exception("Неизвестный режим / трек не найден.")
        };
    }

    public Task Delete(string keyword)
    {
        return context.Tracks!.Where(t => t.Author.ToLower() + t.Name.ToLower() == keyword.Replace(" ",
            "").ToLower()).ExecuteDeleteAsync();
    }
}

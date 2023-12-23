using LizaLab4.Model;

namespace LizaLab4.Repository;

public interface IMRepository
{
    Task Add(Track track);
    Task<List<Track>> Search(string keyword, int mode);
    Task Delete(string keyword);
}

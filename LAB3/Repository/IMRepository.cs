using LizaLab3.Model;

namespace LizaLab3.Repository;

public interface IMRepository
{
    void SaveToDb(List<Track> taskks);
    List<Track> LoadFromDb();
    void SaveToJson(List<Track> taskks);
    List<Track> LoadFromJson();
}

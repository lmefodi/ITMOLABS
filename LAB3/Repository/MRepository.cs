using LizaLab3.Model;
using LizaLab3.Database;
using Newtonsoft.Json;

namespace LizaLab3.Repository;

public class MRepository : IMRepository
{
    private readonly string _jsonFilePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tracks.json");

    private readonly MContext _context = new ();

    public MRepository()
    {
        _context.Database.EnsureCreated();
    }
    public void SaveToDb(List<Track> tracks)
    {
        _context.Tracks?.RemoveRange(_context.Tracks);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.Tracks?.AddRange(tracks);
        _context.SaveChanges();
    }

    public List<Track> LoadFromDb()
    {
        return _context.Tracks!.ToList();
    }

    public void SaveToJson(List<Track> tracks)
    {
        var jsonData = JsonConvert.SerializeObject(tracks, Formatting.Indented);
        File.WriteAllText(_jsonFilePath, jsonData);
    }

    public List<Track> LoadFromJson()
    {
        var temp = new List<Track>();
        File.Create(_jsonFilePath).Close();

        var jsonData = File.ReadAllText(_jsonFilePath);
        var data = JsonConvert.DeserializeObject<List<Track>>(jsonData) ?? new List<Track>();
        foreach (var track in data)
        {
            temp.Add(new Track
            {
                Author = track.Author,
                Name = track.Name
            });
        }

        return temp;
    }
}

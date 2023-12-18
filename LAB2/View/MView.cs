using LizaLab2.Model;

namespace LizaLab2.View;

public class MView : IMView
{
    public void TrackList(List<Track> tracks)
    {
        var count = tracks.Count;
        if (count > 0)
        {
            for (var i = 0; i < count; i++)
                Console.WriteLine(tracks[i].Author + " - " + tracks[i].Name);
        }
        else
            Console.WriteLine("No such tracks.");
    }
    
    public string KeywordRequest()
    {
        var input = Console.ReadLine() ?? "";
        if (input == "")
            throw new Exception("An empty string is not allowed.");
        return input;
    }
    
    public int SearchMode()
    {
        Console.WriteLine(
            "Search by:\n1. Name.\n2. Author.\n3. Name and Author.");
        Console.Write("> ");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid || n < 1 || n > 3)
            throw new Exception("Invalid value.");
        return n;
    }
}

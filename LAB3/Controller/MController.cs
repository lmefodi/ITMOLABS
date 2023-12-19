using System.Text.RegularExpressions;
using LizaLab3.Model;
using LizaLab3.Repository;
using LizaLab3.View;

namespace LizaLab3.Controller;

public class MController
{
    private List<Track> _tracks;
    private readonly IMView _mView;
    private readonly IMRepository _mRepository;

    public MController(List<Track> tracks, IMView mView, IMRepository mRepository)
    {
        _tracks = tracks;
        _mView = mView;
        _mRepository = mRepository;
    }

    public void AddTrack(Track track)
    {
        _tracks.Add(track);
    }

    public void DeleteTrack(string keyword)
    {
        foreach (var track in _tracks)
        {
            if (Regex.Replace((track.Author + track.Name).ToLower(), @"[\s-]", "")
                == Regex.Replace(keyword.ToLower(), @"[\s-]", ""))
            {
                _tracks.Remove(track);
                break;
            }
        }
    }

    public List<Track> Search(string keyword, int mode)
    {
        var flag = false;
        var temp = new List<Track>();
        var regex = new Regex($@"{keyword.ToLower()}(\w*)");
        foreach (var track in _tracks)
        {
            switch (mode)
            {
                case 1:
                    if (regex.Matches(track.Name.ToLower()).Count > 0)
                    {
                        flag = true;
                        temp.Add(track);
                    }

                    break;
                case 2:
                    if (regex.Matches(track.Author.ToLower()).Count > 0)
                    {
                        flag = true;
                        temp.Add(track);
                    }

                    break;
                case 3:
                    if (regex.Matches(track.Name.ToLower()).Count > 0 ||
                        regex.Matches(track.Author.ToLower()).Count > 0)
                    {
                        flag = true;
                        temp.Add(track);
                    }

                    break;
            }
        }

        if (!flag)
            Console.WriteLine("No such tracks");
        return temp;
    }


    public void Run()
    {
        Console.WriteLine(
            "Usage:\nType one of commands:\n'list' to display all items of catalog.\n'search' to go find items in catalog." +
            "\n'add' to add new item.\n'del' to remove some item from list.\n'quit' to exit.");

        int slmode = _mView.GetSaveAndLoad();
        
        switch (slmode)
        {
            case 1:
                _tracks = _mRepository.LoadFromDb();
                break;
            case 2:
                _tracks = _mRepository.LoadFromJson();
                break;
        }
        
        var running = true;
        while (running)
        {
            Console.WriteLine("____\nInput the command:");
            var input = Console.ReadLine() ?? "";

            switch (input.ToLower())
            {
                case "list":
                    Console.WriteLine("All compositions in catalog:");
                    _mView.TrackList(_tracks);
                    break;
                case "search":
                    int mode = _mView.SearchMode();
                    Console.WriteLine("Input the part of the name to find composition in the catalog:");
                    _mView.TrackList(Search(_mView.KeywordRequest(), mode));
                    break;
                case "add":
                    var tempTrack = new Track();
                    Console.WriteLine("Input author's name:");
                    tempTrack.Author = _mView.KeywordRequest();
                    Console.WriteLine("Input composition's name:");
                    tempTrack.Name = _mView.KeywordRequest();
                    AddTrack(tempTrack);
                    break;
                case "del":
                    Console.WriteLine("Input the full name of the track to remove:");
                    DeleteTrack(_mView.KeywordRequest());
                    break;
                case "quit":
                    running = !running;
                    break;
                default:
                    throw new Exception("Unknown command.");
            }
        }
        
        switch (slmode)
        {
            case 1:
                _mRepository.SaveToDb(_tracks);
                break;
            case 2:
                _mRepository.SaveToJson(_tracks);
                break;
        }
        
    }
}

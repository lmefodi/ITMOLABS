using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace LizaLab5.Models;

public class MusicTrack: ReactiveObject
{
    [Key]
    public int Id { get; set; }
    
    
    private string _title;
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }
    
    private string _author;
    public string Author
    {
        get => _author;
        set => this.RaiseAndSetIfChanged(ref _author, value);
    }
    
}

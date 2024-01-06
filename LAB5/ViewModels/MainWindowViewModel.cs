using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DynamicData;
using LizaLab5.Repository;
using LizaLab5.Database;
using LizaLab5.Models;
using LizaLab5.Views;
using ReactiveUI;

namespace LizaLab5.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly MyContext _context;
    private readonly IMyRepository _repository;
    
    public MainWindowViewModel()
    {
        _context = new MyContext();
        _repository = new MyRepository(_context);
        var t = _repository.LoadFromDb();
        TrackList.AddRange(t);
        TrackList = new ObservableCollection<MusicTrack>(_repository.LoadFromDb());
        FilteredList = new ObservableCollection<MusicTrack>(TrackList);
    }

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
    
    private string _filterWord;
    public string FilterWord
    {
        get => _filterWord;
        set => this.RaiseAndSetIfChanged(ref _filterWord, value);
    }
    
    
    private int selectedIndex;
    public int SelectedIndex
    {
        get { return selectedIndex; }
        set { this.RaiseAndSetIfChanged(ref selectedIndex, value); }
    }
    
    
    private MusicTrack _selectedItem;
    public MusicTrack SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedItem, value);
            if (value != null)
            {
                Title = SelectedItem.Title;
                Author = SelectedItem.Author;
            }
        }
    }

    
    public ObservableCollection<MusicTrack> TrackList { get; set; } = [];
    
    public ObservableCollection<MusicTrack> FilteredList { get; set; }

    public void ShowAddTrackDialog()
    {
            var dialog = new DialogWindow();
            dialog.DataContext = new DialogViewModel(this, dialog);

            dialog.Show();
    }
    
    public void ShowEditTrackDialog()
    {
        if (SelectedItem != null)
        {
            var dialog = new DialogWindow();
            dialog.DataContext = new DialogViewModel(this, dialog, SelectedItem);

            dialog.Show();
        }
    }

    public void UpdateFiltered(ObservableCollection<MusicTrack> musicTracks)
    {
        FilteredList.Clear();
        FilteredList.AddRange(musicTracks);
    }
    public async Task AddTrack(MusicTrack musicTrack)
    {
        await Task.Delay(1000);

        TrackList.Add(musicTrack);
        UpdateFiltered(TrackList);
        _repository.SaveToDb(TrackList);
    }
    
    public async Task SaveChanges(MusicTrack musicTrack)
    {
        await Task.Delay(1000);

        foreach (var track in TrackList)
        {
            if (track == SelectedItem)
            {
                track.Title = musicTrack.Title;
                track.Author = musicTrack.Author;
            }
        }

        _repository.SaveToDb(TrackList);
    }

    public void DeleteTrack()
    {
        if (SelectedItem != null)
        {
            TrackList.Remove(SelectedItem);
            UpdateFiltered(TrackList);
        }
    }

    public void Filter()
    {
        FilteredList.Clear();
        var regex =  new Regex($@"{FilterWord}(\w*)");
        if (FilterWord == "")
            FilteredList.AddRange(TrackList);
        else
        {
            if (SelectedIndex == 0)
            {
                foreach (var track in TrackList)
                {
                    if (regex.Matches(track.Title).Count > 0)
                        FilteredList.Add(track);
                }
            }
            else if (SelectedIndex == 1)
            {
                foreach (var track in TrackList)
                {
                    if (regex.Matches(track.Author).Count > 0)
                        FilteredList.Add(track);
                }
            }
            else if (SelectedIndex == 2)
            {
                foreach (var track in TrackList)
                {
                    if (regex.Matches(track.Author).Count > 0 || regex.Matches(track.Title).Count > 0)
                        FilteredList.Add(track);
                }
            }
        }
    }
    
    
}

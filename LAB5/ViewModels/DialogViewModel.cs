using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Media;
using LizaLab5.Models;
using LizaLab5.Views;
using ReactiveUI;

namespace LizaLab5.ViewModels;

public sealed class DialogViewModel : ViewModelBase
{
    private MusicTrack _musicTrack;
    private string _title;
    private string _author;
    
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly DialogWindow _dialog;
    private readonly Button _button;

    public DialogViewModel(MainWindowViewModel mwvm, DialogWindow dialog)
    {
        _mainWindowViewModel = mwvm;
        _dialog = dialog;
        _button = _dialog.FindControl<Button>("OkButton");
    }
    
    public DialogViewModel(MainWindowViewModel mwvm, DialogWindow dialog, MusicTrack musicTrack)
    {
        _mainWindowViewModel = mwvm;
        _dialog = dialog;
        _musicTrack = musicTrack;
        Title = _musicTrack.Title;
        Author = _musicTrack.Author;
        _button = _dialog.FindControl<Button>("OkButton");
    }
    
    
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    public string Author
    {
        get => _author;
        set => this.RaiseAndSetIfChanged(ref _author, value);
    }

    private bool IsInputWordValid()
    {
        return Author != "" && Title != "";
    }

    public async void AddTrack()
    {
        if (IsInputWordValid())
        {
            _button.Background = Brushes.Chartreuse;
            if (_musicTrack != null)
                await _mainWindowViewModel.SaveChanges(new MusicTrack{Title = Title, Author = Author});
            else
                await _mainWindowViewModel.AddTrack(new MusicTrack{Title = Title, Author = Author});
            _dialog.Close();
        }
        else
        {
            _button.Background = Brushes.Red;
        }
    }
}

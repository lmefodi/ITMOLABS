using System.Collections.Generic;
using System.Collections.ObjectModel;
using LizaLab5.Models;

namespace LizaLab5.Repository;

public interface IMyRepository
{
    void SaveToDb(ObservableCollection<MusicTrack> tracks);
    List<MusicTrack> LoadFromDb();
}

using LizaLab3.Model;

namespace LizaLab3.View;

public interface IMView
{
    void TrackList(List<Track> tracks);
    string KeywordRequest();
    int SearchMode();
    int GetSaveAndLoad();
}

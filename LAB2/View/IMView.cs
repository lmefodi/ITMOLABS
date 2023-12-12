using LizaLab2.Model;

namespace LizaLab2.View;

public interface IMView
{
    void TrackList(List<Track> tracks);
    string KeywordRequest();
    int SearchMode();
}

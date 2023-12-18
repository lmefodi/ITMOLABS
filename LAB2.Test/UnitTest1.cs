using LizaLab2.Controller;
using LizaLab2.Model;
using LizaLab2.View;

namespace LizaLab2.Test;

public class UnitTest1
{
    [Theory]
    [InlineData("Boulevard Depo", "Friendly Fire", "I61", "GOROD POD VODOY")]
    public void DeleteTrackTest(string author1, string name1, string author2, string name2)
    {
        var tracks = new List<Track>();
        var mView = new MView();
        var mContoller = new MController(tracks, mView);
        mContoller.AddTrack(new Track { Author = author1, Name = name1 });
        mContoller.AddTrack(new Track { Author = author2, Name = name2 });
        mContoller.DeleteTrack(author1 + name1);
        Assert.Single(tracks);
    }

    [Theory]
    [InlineData("Boulevard Depo", "Friendly Fire", "I61", "GOROD POD VODOY")]
    public void SearchByAuthorTest(string author1, string name1, string author2, string name2)
    {
        var tracks = new List<Track>();
        var mView = new MView();
        var mContoller = new MController(tracks, mView);
        mContoller.AddTrack(new Track { Author = author1, Name = name1 });
        mContoller.AddTrack(new Track { Author = author2, Name = name2 });
        Assert.Equal(mContoller.Search(author1, 2)[0], tracks[0]);
    }
}

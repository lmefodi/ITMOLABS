using LizaLab3.Controller;
using LizaLab3.Model;
using LizaLab3.Repository;
using LizaLab3.View;

namespace LizaLab3;

public static class Program
{
    public static void Main(string[] args)
    {
        var tracks = new List<Track>();
        var mView = new MView();
        var mRepository = new MRepository();
        var mContoller = new MController(tracks, mView, mRepository);
        mContoller.Run();
    }
}

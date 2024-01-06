using LizaLab4.Model;
using LizaLab4.Services;

namespace LizaLab4.Services;

public class StoreTrack : IStoreTrack
{
    private readonly IValidation _validator;
    public StoreTrack(IValidation validator)
    {
        _validator = validator;
    }
    
    public Track SetTrack(string name, string author)
    {
        var track = new Track{Name = name, Author = author};

        _validator.ValidateTrack(track);
        return track;

    }
}

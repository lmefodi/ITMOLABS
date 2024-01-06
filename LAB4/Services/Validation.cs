using LizaLab4.Model;

namespace LizaLab4.Services;

public class Validation : IValidation
{
    public void ValidateTrack(Track track)
    {
        if (track.Name=="" || track.Author=="")
            throw new Exception("Empty fields are not allowed");
    }
}

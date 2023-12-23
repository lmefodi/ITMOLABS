using LizaLab4.Model;
using LizaLab4.Repository;
using LizaLab4.Services;
using Microsoft.AspNetCore.Mvc;

namespace LizaLab4.Controller;

public class MController
{
    private readonly IMRepository _mRepository;

    public MController(IMRepository mRepository)
    {
        _mRepository = mRepository;
    }

    [HttpPost]
    [Route("/add-track")]
    public Task Add([FromBody] string fake, string name, string author)
    {
        var validator = new Validation();
        var storeTask = new StoreTrack(validator);
        var track = storeTask.SetTrack(name, author);

        return _mRepository.Add(track);
    }

    [HttpGet]
    [Route("/search-track")]
    public Task<List<Track>> Search(string keyword, int mode)
    {
        return _mRepository.Search(keyword, mode);
    }

    [HttpGet]
    [Route("/delete-track")]
    public Task Delete(string keyword)
    {
        return _mRepository.Delete(keyword);
    }
}

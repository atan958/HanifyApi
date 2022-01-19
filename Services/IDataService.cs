using System.Collections.Generic;
using apis.Models;

namespace apis.Services
{
    public interface IDataService
    {
        IEnumerable<SpotifyGroup> GetAll();

        SpotifyGroup Get(string id);

        void Post(SpotifyGroup group);
    }
}
namespace OnlineStore.Services.Data
{
    using System.Linq;

    using OnlineStore.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}

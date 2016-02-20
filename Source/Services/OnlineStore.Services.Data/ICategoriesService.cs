namespace OnlineStore.Services.Data
{
    using System.Linq;

    using OnlineStore.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}

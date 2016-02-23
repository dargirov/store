namespace OnlineStore.Services.Data
{
    using System.Linq;
    using OnlineStore.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        Category GetByAcronym(string acronym);
    }
}

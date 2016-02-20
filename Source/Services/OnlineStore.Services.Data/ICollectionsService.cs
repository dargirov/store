namespace OnlineStore.Services.Data
{
    using System.Linq;
    using OnlineStore.Data.Models;

    public interface ICollectionsService
    {
        IQueryable<Collection> GetActive();

        IQueryable<Collection> GetByAcronym(string acronym);
    }
}

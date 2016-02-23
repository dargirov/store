namespace OnlineStore.Services.Data
{
    using System;
    using System.Linq;
    using OnlineStore.Data.Models;

    public interface ICollectionsService
    {
        Collection GetById(int id);

        IQueryable<Collection> GetActive();

        IQueryable<Collection> GetAll();

        IQueryable<Collection> GetAllWidthDeleted();

        IQueryable<Collection> GetByAcronym(string acronym);

        int Count();

        int Create(string name, string shortDescription, string description, decimal discount, DateTime dateStart, DateTime dateEnd, int categoryId, string image);

        void Delete(int id);

        void Update();
    }
}

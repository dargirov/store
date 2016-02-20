namespace OnlineStore.Services.Data
{
    using System;
    using System.Linq;
    using OnlineStore.Data.Common;
    using OnlineStore.Data.Models;

    public class CollectionsService : ICollectionsService
    {
        private readonly IDbRepository<Collection> collections;

        public CollectionsService(IDbRepository<Collection> collections)
        {
            this.collections = collections;
        }

        public IQueryable<Collection> GetActive()
        {
            var now = DateTime.Now;

            return this.collections
                .All()
                .Where(c => c.IsActive && now >= c.DateStart && now <= c.DateEnd)
                .OrderBy(c => c.DateStart)
                .ThenBy(c => c.Id);
        }

        public IQueryable<Collection> GetByAcronym(string acronym)
        {
            return this.collections
                .All()
                .Where(c => c.Acronym == acronym);
        }
    }
}

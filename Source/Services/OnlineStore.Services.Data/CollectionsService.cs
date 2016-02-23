namespace OnlineStore.Services.Data
{
    using System;
    using System.Linq;
    using OnlineStore.Data.Common;
    using OnlineStore.Data.Models;
    using Web;

    public class CollectionsService : ICollectionsService
    {
        private readonly IDbRepository<Collection> collections;
        private readonly IAcronymGenerator acronymGenerator;

        public CollectionsService(IDbRepository<Collection> collections, IAcronymGenerator acronymGenerator)
        {
            this.collections = collections;
            this.acronymGenerator = acronymGenerator;
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

        public IQueryable<Collection> GetAll()
        {
            return this.collections
                .All()
                .OrderByDescending(c => c.Id);
        }

        public IQueryable<Collection> GetByAcronym(string acronym)
        {
            return this.collections
                .All()
                .Where(c => c.Acronym == acronym);
        }

        public int Create(string name, string shortDescription, string description, decimal discount, DateTime dateStart, DateTime dateEnd, int categoryId, string image)
        {
            var collection = new Collection()
            {
                Name = name,
                Acronym = this.acronymGenerator.Generate(name),
                ShortDescription = shortDescription,
                Description = description,
                Image = image,
                Discount = discount,
                DateStart = dateStart,
                DateEnd = dateEnd,
                CategoryId = categoryId,
                IsActive = false,
            };

            this.collections.Add(collection);
            this.collections.Save();
            return collection.Id;
        }

        public void Delete(int id)
        {
            var collection = this.collections.GetById(id);
            this.collections.Delete(collection);
            this.collections.Save();
        }

        public IQueryable<Collection> GetAllWidthDeleted()
        {
            return this.collections
                .AllWithDeleted()
                .OrderByDescending(c => c.Id);
        }

        public Collection GetById(int id)
        {
            return this.collections
                .GetById(id);
        }

        public int Count()
        {
            return this.collections
                .AllWithDeleted()
                .Count();
        }

        public void Update()
        {
            this.collections.Save();
        }
    }
}

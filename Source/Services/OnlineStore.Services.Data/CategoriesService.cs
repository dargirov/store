namespace OnlineStore.Services.Data
{
    using System.Linq;

    using OnlineStore.Data.Common;
    using OnlineStore.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDbRepository<Category> categories;

        public CategoriesService(IDbRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories
                .All()
                .Where(c => c.IsActive)
                .OrderBy(x => x.Name);
        }
    }
}

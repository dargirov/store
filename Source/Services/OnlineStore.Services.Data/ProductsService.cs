namespace OnlineStore.Services.Data
{
    using System;
    using System.Linq;
    using OnlineStore.Data.Common;
    using OnlineStore.Data.Models;

    public class ProductsService : IProductsService
    {
        private readonly IDbRepository<Product> products;

        public ProductsService(IDbRepository<Product> products)
        {
            this.products = products;
        }

        public IQueryable<Product> GetByAcronym(string acronym)
        {
            return this.products
                .All()
                .Where(p => p.Acronym == acronym);
        }

        public Product GetById(int id)
        {
            return this.products
                .GetById(id);
        }
    }
}

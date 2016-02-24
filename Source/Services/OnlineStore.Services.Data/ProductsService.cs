namespace OnlineStore.Services.Data
{
    using System.Linq;
    using OnlineStore.Data.Common;
    using OnlineStore.Data.Models;
    using Web;

    public class ProductsService : IProductsService
    {
        private readonly IDbRepository<Product> products;
        private readonly IAcronymGenerator acronymGenerator;

        public ProductsService(IDbRepository<Product> products, IAcronymGenerator acronymGenerator)
        {
            this.products = products;
            this.acronymGenerator = acronymGenerator;
        }

        public int Create(Product product)
        {
            product.Acronym = this.acronymGenerator.Generate(product.Name);
            this.products.Add(product);
            this.products.Save();
            return product.Id;
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

        public IQueryable<Product> GetByCollectionId(int collectionId)
        {
            return this.products
                .All()
                .Where(p => p.CollectionId == collectionId)
                .OrderByDescending(p => p.Id);
        }
    }
}

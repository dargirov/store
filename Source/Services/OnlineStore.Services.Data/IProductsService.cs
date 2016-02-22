namespace OnlineStore.Services.Data
{
    using System.Linq;
    using OnlineStore.Data.Models;

    public interface IProductsService
    {
        IQueryable<Product> GetByAcronym(string acronym);

        Product GetById(int id);
    }
}

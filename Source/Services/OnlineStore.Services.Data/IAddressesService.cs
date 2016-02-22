namespace OnlineStore.Services.Data
{
    using System.Linq;
    using OnlineStore.Data.Models;

    public interface IAddressesService
    {
        IQueryable<City> GetCities();
    }
}

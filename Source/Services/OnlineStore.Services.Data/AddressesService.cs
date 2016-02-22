namespace OnlineStore.Services.Data
{
    using System;
    using System.Linq;
    using OnlineStore.Data.Common;
    using OnlineStore.Data.Models;

    public class AddressesService : IAddressesService
    {
        private readonly IDbRepository<City> cities;

        public AddressesService(IDbRepository<City> cities)
        {
            this.cities = cities;
        }

        public IQueryable<City> GetCities()
        {
            return this.cities.All().OrderBy(c => c.Name);
        }
    }
}

namespace OnlineStore.Web.Areas.Cart.ViewModels.Cart
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AddressViewModel : IMapFrom<Address>
    {
        public IEnumerable<City> Cities { get; set; }

        public string Street { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }
    }
}

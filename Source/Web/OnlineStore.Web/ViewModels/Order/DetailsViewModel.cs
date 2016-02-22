namespace OnlineStore.Web.ViewModels.Order
{
    using System.Collections.Generic;
    using Areas.Cart.ViewModels.Cart;
    using Data.Models;
    using Infrastructure.Mapping;

    public class DetailsViewModel : IMapFrom<Order>
    {
        public OrderStatus Status { get; set; }

        public IEnumerable<OrderProductViewModel> Products { get; set; }

        public Address Address { get; set; }

        public decimal CurrentProductPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

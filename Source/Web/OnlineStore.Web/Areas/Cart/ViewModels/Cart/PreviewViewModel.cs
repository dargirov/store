namespace OnlineStore.Web.Areas.Cart.ViewModels.Cart
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PreviewViewModel : IMapFrom<Order>
    {
        public OrderStatus Status { get; set; }

        public IEnumerable<OrderProductViewModel> Products { get; set; }
    }
}
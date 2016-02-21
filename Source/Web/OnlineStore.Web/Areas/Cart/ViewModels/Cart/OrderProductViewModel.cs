namespace OnlineStore.Web.Areas.Cart.ViewModels.Cart
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrderProductViewModel : IMapFrom<OrderProduct>
    {
        public int Reserved { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }
    }
}
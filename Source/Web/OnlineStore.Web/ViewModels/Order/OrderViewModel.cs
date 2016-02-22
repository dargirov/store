namespace OnlineStore.Web.ViewModels.Order
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrderViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }
    }
}

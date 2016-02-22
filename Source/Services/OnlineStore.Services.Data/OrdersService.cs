namespace OnlineStore.Services.Data
{
    using System.Linq;
    using OnlineStore.Data.Common;
    using OnlineStore.Data.Models;

    public class OrdersService : IOrdersService
    {
        private readonly IDbRepository<Order> orders;
        private readonly IDbRepository<OrderProduct> orderProducts;

        public OrdersService(IDbRepository<Order> orders, IDbRepository<OrderProduct> orderProducts)
        {
            this.orders = orders;
            this.orderProducts = orderProducts;
        }

        public void Create(Order order)
        {
            this.orders.Add(order);

            foreach (var product in order.Products)
            {
                this.orderProducts.Add(product);
            }

            this.orderProducts.Save();
            this.orders.Save();
        }

        public Order GetById(int id)
        {
            var order = this.orders.GetById(id);
            order.Products = this.orderProducts
                .All()
                .Where(p => p.OrderId == id)
                .ToList();
            return order;
        }

        public Order Update(Order order)
        {
            var oldOrder = this.orders.GetById(order.Id);
            oldOrder.Products = order.Products;
            this.orders.Save();
            return oldOrder;
        }

        public IQueryable<Order> GetByUserId(string userId)
        {
            return this.orders
                .All()
                .Where(o => o.UserId == userId);
        }
    }
}

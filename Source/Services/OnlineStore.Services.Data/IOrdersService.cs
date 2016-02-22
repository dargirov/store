namespace OnlineStore.Services.Data
{
    using System.Linq;
    using OnlineStore.Data.Models;

    public interface IOrdersService
    {
        void Create(Order order);

        Order GetById(int id);

        Order Update(Order order);

        IQueryable<Order> GetByUserId(string userId);
    }
}

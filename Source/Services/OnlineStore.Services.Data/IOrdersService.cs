namespace OnlineStore.Services.Data
{
    using OnlineStore.Data.Models;

    public interface IOrdersService
    {
        void Create(Order order);

        Order GetById(int id);

        Order Update(Order order);
    }
}

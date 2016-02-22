namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum OrderStatus
    {
        Session = 1,
        Requested = 2,
        Confirmed = 3,
        Finished = 4
    }
}

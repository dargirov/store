namespace OnlineStore.Web.ViewModels.Order
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; } 
    }
}

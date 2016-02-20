namespace OnlineStore.Web.ViewModels.Collection
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public CollectionViewModel Collection { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}

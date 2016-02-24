namespace OnlineStore.Web.Areas.Administration.ViewModels.Product
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class IndexViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int CollectionId { get; set; }

        public Collection Collection { get; set; }

        public IEnumerable<ProductVariant> Variants { get; set; }
    }
}

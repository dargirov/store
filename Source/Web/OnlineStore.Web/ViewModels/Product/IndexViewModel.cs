namespace OnlineStore.Web.ViewModels.Product
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class IndexViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Acronym { get; set; }

        public string Description { get; set; }

        public int CollectionId { get; set; }

        public IEnumerable<VariantViewModel> Variants { get; set; }

        public IEnumerable<ProductImage> Images { get; set; }

        public IEnumerable<Product> RelatedProducts { get; set; }
    }
}
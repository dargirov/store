namespace OnlineStore.Web.ViewModels.Product
{
    using System.Collections.Generic;
    using Infrastructure.Mapping;

    public class IndexViewModel : IMapFrom<Data.Models.Product>
    {
        public string Name { get; set; }

        public string Acronym { get; set; }

        public string Description { get; set; }

        public IEnumerable<VariantViewModel> Variants { get; set; }
    }
}
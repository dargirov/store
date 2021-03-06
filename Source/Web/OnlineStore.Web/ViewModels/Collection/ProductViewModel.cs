﻿namespace OnlineStore.Web.ViewModels.Collection
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Acronym { get; set; }

        public IEnumerable<ProductImage> Images { get; set; }

        public IEnumerable<VariantViewModel> Variants { get; set; }
    }
}

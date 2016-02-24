namespace OnlineStore.Web.ViewModels.Collection
{
    using System;
    using System.Collections.Generic;
    using Infrastructure.Mapping;

    public class IndexViewModel : IMapFrom<Data.Models.Collection>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Acronym { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Discount { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateEnd { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}

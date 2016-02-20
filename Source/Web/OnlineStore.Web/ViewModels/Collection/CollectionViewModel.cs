namespace OnlineStore.Web.ViewModels.Collection
{
    using System;
    using Infrastructure.Mapping;

    public class CollectionViewModel : IMapFrom<Data.Models.Collection>
    {
        public string Name { get; set; }

        public string Acronym { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Discount { get; set; }

        public DateTime DateEnd { get; set; }
    }
}

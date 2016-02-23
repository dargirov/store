namespace OnlineStore.Web.Areas.Administration.ViewModels.Collection
{
    using System;
    using Infrastructure.Mapping;

    public class IndexViewModel : IMapFrom<Data.Models.Collection>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public decimal Discount { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public bool IsDeleted { get; set; }
    }
}

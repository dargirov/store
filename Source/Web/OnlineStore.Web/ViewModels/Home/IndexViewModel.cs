namespace OnlineStore.Web.ViewModels.Home
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class IndexViewModel : IMapFrom<Collection>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public decimal Discount { get; set; }

        public string ShortDescription { get; set; }

        public string Acronym { get; set; }
    }
}

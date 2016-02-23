namespace OnlineStore.Web.ViewModels.Home
{
    using Infrastructure.Mapping;

    public class CategoriesViewModel : IMapFrom<Data.Models.Category>
    {
        public string Name { get; set; }

        public string Acronym { get; set; }
    }
}

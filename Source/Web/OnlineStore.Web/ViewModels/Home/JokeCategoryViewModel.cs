namespace OnlineStore.Web.ViewModels.Home
{
    using OnlineStore.Data.Models;
    using OnlineStore.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

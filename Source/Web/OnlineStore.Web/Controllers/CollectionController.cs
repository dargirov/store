namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Collection;

    public class CollectionController : BaseController
    {
        private readonly ICollectionsService collections;

        public CollectionController(ICollectionsService collections)
        {
            this.collections = collections;
        }

        public ActionResult Index(string acronym)
        {
            var collection = this.collections.GetByAcronym(acronym);
            if (collection == null)
            {
                return this.HttpNotFound();
            }

            var products = collection.Products.Where(p => p.IsActive).AsQueryable().To<ProductViewModel>().ToList();

            var viewModel = new IndexViewModel()
            {
                Collection = this.Mapper.Map<CollectionViewModel>(collection),
                Products = products
            };

            return this.View(viewModel);
        }
    }
}
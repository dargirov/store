namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ICollectionsService collections;
        private readonly ICategoriesService categories;
        private readonly IProductsService products;

        public HomeController(ICollectionsService collections, ICategoriesService categories, IProductsService products)
        {
            this.collections = collections;
            this.categories = categories;
            this.products = products;
        }

        public ActionResult Index()
        {
            var viewModel = this.Cache.Get("collections", () => this.collections.GetActive().To<IndexViewModel>().ToList(), 1 * 60);

            return this.View(viewModel);
        }

        public ActionResult Category(string id)
        {
            var category = this.categories.GetByAcronym(id);
            if (category == null)
            {
                return this.RedirectToAction("Index");
            }

            var viewModel = this.collections.GetActive().Where(c => c.CategoryId == category.Id).To<IndexViewModel>().ToList();

            return this.View("Index", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {
            var viewModel = this.products.GetAll()
                .Where(p => p.Name.Contains(search) && p.IsActive && !p.IsDeleted)
                .To<ViewModels.Collection.ProductViewModel>().ToList();

            return this.View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            var viewModel = this.categories.GetAll().Where(c => c.IsActive).To<CategoriesViewModel>().ToList();
            return this.PartialView("_CategoriesPartial", viewModel);
        }
    }
}

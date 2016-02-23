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

        public HomeController(ICollectionsService collections, ICategoriesService categories)
        {
            this.collections = collections;
            this.categories = categories;
        }

        public ActionResult Index()
        {
            var viewModel = this.collections.GetActive().To<IndexViewModel>().ToList();

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

        [ChildActionOnly]
        public ActionResult GetCategories()
        {
            var viewModel = this.categories.GetAll().Where(c => c.IsActive).To<CategoriesViewModel>().ToList();
            return this.PartialView("_CategoriesPartial", viewModel);
        }
    }
}

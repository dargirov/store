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
            var viewModel = this.Cache.Get("collection_" + acronym, () => this.collections.GetByAcronym(acronym).To<IndexViewModel>().FirstOrDefault(), 1 * 60);
            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            return this.View(viewModel);
        }
    }
}

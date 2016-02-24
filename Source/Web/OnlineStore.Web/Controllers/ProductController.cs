namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Product;

    public class ProductController : BaseController
    {
        private readonly IProductsService products;

        public ProductController(IProductsService products)
        {
            this.products = products;
        }

        public ActionResult Index(string acronym)
        {
            var viewModel = this.products.GetByAcronym(acronym).To<IndexViewModel>().FirstOrDefault();
            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            var related = this.products.GetByCollectionId(viewModel.CollectionId).Where(p => p.Id != viewModel.Id).ToList();
            viewModel.RelatedProducts = related;

            return this.View(viewModel);
        }
    }
}

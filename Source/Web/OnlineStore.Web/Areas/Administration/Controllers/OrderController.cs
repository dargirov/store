namespace OnlineStore.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Order;
    using Web.Controllers;

    public class OrderController : BaseController
    {
        private IOrdersService orders;

        public OrderController(IOrdersService orders)
        {
            this.orders = orders;
        }

        public ActionResult Index()
        {
            var viewModel = this.orders.GetAll().To<IndexViewModel>().ToList();
            return this.View(viewModel);
        }
    }
}
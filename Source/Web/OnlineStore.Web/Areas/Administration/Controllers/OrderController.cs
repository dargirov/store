namespace OnlineStore.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Order;
    using Web.Controllers;
    using Data.Models;
    using System.Net;
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

        [HttpGet]
        public ActionResult Details(int id)
        {
            var order = this.orders.GetById(id);
            var viewModel = this.Mapper.Map<DetailsViewModel>(order);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatus(int? id, OrderStatus status)
        {
            if (id == null)
            {
                return this.Json(new { success = false, error = "Invalid id" });
            }

            var order = this.orders.GetById(int.Parse(id.ToString()));
            order.Status = status;
            this.orders.Update(order);

            return this.Json(new { success = true, error = string.Empty });
        }
    }
}

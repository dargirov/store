namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.Order;

    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrdersService orders;

        public OrderController(IOrdersService orders)
        {
            this.orders = orders;
        }

        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();

            var viewModel = new IndexViewModel()
            {
                Orders = this.orders.GetByUserId(userId).OrderByDescending(o => o.Id).To<OrderViewModel>()
            };

            return this.View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var userId = this.User.Identity.GetUserId();
            var order = this.orders.GetById(id);

            if (order == null || order.UserId != userId)
            {
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            var viewModel = this.Mapper.Map<DetailsViewModel>(order);

            return this.View(viewModel);
        }
    }
}

namespace OnlineStore.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
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

        public ActionResult Index(int id = 1)
        {
            var page = id;
            var allItemsCount = this.orders.Count();
            var itemsPerPage = GlobalConstants.AdminItemsPerPage;

            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)itemsPerPage);
            var itemsToSkip = (page - 1) * itemsPerPage;

            var viewModel = this.orders
                .GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemsToSkip)
                .Take(itemsPerPage)
                .To<IndexViewModel>().ToList();

            this.ViewBag.CurrentPage = page;
            this.ViewBag.TotalPages = totalPages;

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

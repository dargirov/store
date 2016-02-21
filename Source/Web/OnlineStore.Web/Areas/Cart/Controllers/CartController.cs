namespace OnlineStore.Web.Areas.Cart.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels;
    using Web.Controllers;

    [Authorize]
    public class CartController : BaseController
    {
        private readonly IOrdersService orders;
        private readonly IProductsService products;

        public CartController(IOrdersService orders, IProductsService products)
        {
            this.orders = orders;
            this.products = products;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Preview()
        {
            var order = this.GetOrderFromSession();
            if (order == null)
            {
                return this.HttpNotFound();
            }

            return this.PartialView("_PreviewPartial");
        }

        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var product = this.products.GetByAcronym(model.Acronym).FirstOrDefault();
                if (product == null)
                {
                    return this.Json(new { success = false, error = "Продуктът не е намерен" });
                }

                var variantId = product.Variants.Where(v => v.Internal == model.Internal).Select(v => v.Id).FirstOrDefault();
                var quantityAvaiable = product.Variants.Where(v => v.Internal == model.Internal).Select(v => v.Quantity - v.Reserved).FirstOrDefault();

                if (model.Quantity > quantityAvaiable)
                {
                    return this.Json(new { success = false, error = "Няма достатъчно количество от избрания модел" });
                }

                var order = this.GetOrderFromSession();
                if (order == null)
                {
                    var orderId = this.CreateOrder(product.Id, variantId, model.Quantity);
                    this.Session["orderId"] = orderId;
                }
                else
                {
                    var orderId = this.UpdateOrder(order, product.Id, variantId, model.Quantity);
                }

                return this.Json(new { success = true, error = string.Empty });
            }

            return this.Json(new { success = false, error = "modelState" });
        }

        private int UpdateOrder(Order order, int productId, int variantId, int quantity)
        {
            Order updatedOrder;
            var inCart = order.Products.Where(p => p.ProductId == productId && p.ProductVariantId == variantId).FirstOrDefault();
            if (inCart == null)
            {
                // this is a new product/variant
                // add to cart
                inCart = new OrderProduct()
                {
                    ProductId = productId,
                    ProductVariantId = variantId,
                    Reserved = quantity
                };

                order.Products.Add(inCart);
                updatedOrder = this.orders.Update(order);
            }
            else
            {
                // update the quantity
                inCart.Reserved = quantity;
                updatedOrder = this.orders.Update(order);
            }

            return updatedOrder.Id;
        }

        private int CreateOrder(int productId, int variantId, int quantity)
        {
            var productsList = new List<OrderProduct>();
            productsList.Add(new OrderProduct()
            {
                ProductId = productId,
                ProductVariantId = variantId,
                Reserved = quantity
            });

            var order = new Order()
            {
                UserId = this.User.Identity.GetUserId(),
                Products = productsList,
                Status = OrderStatus.Session
            };

            this.orders.Create(order);
            return order.Id;
        }

        private Order GetOrderFromSession()
        {
            var id = (int?)this.Session["orderId"];
            if (id == null)
            {
                return null;
            }

            int idAsInt = int.Parse(id.ToString());
            return this.orders.GetById(idAsInt);
        }
    }
}

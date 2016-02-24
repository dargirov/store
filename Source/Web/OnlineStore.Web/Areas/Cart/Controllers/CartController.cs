namespace OnlineStore.Web.Areas.Cart.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.Cart;
    using Web.Controllers;

    [Authorize]
    public class CartController : BaseController
    {
        private readonly IOrdersService orders;
        private readonly IProductsService products;
        private readonly IAddressesService addresses;

        public CartController(IOrdersService orders, IProductsService products, IAddressesService addresses)
        {
            this.orders = orders;
            this.products = products;
            this.addresses = addresses;
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
                return this.PartialView("_EmptyPartial");
            }

            var viewModel = this.Mapper.Map<PreviewViewModel>(order);

            return this.PartialView("_PreviewPartial", viewModel);
        }

        [HttpGet]
        public ActionResult Address()
        {
            var order = this.GetOrderFromSession();
            if (order == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = new AddressViewModel()
            {
                Cities = this.addresses.GetCities()
            };

            return this.PartialView("_AddressPartial", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(AddressViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpNotFound();
            }

            var order = this.GetOrderFromSession();
            if (order == null)
            {
                return this.HttpNotFound();
            }

            order.Address = new Address()
            {
                CityId = int.Parse(model.CityId.ToString()),
                Comment = model.Comment,
                Phone = model.Phone,
                Street = model.Street,
                UserId = this.User.Identity.GetUserId()
            };

            var updatedOrder = this.orders.Update(order);

            var viewModel = new ConfirmViewModel()
            {
                Preview = this.Mapper.Map<PreviewViewModel>(updatedOrder),
                Address = model
            };

            return this.PartialView("_ConfirmPartial", viewModel);
        }

        [HttpGet]
        public ActionResult Finish()
        {
            var orderId = (int?)this.Session["orderId"];
            if (orderId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "No order id");
            }

            var order = this.orders.GetById(int.Parse(orderId.ToString()));
            order.Status = OrderStatus.Requested;

            // update reserved quantity
            foreach (var orderProduct in order.Products)
            {
                var product = this.products.GetById(orderProduct.ProductId);
                var productVariant = product.Variants.Where(v => v.Id == orderProduct.ProductVariantId).FirstOrDefault();
                if (productVariant != null)
                {
                    productVariant.Reserved += orderProduct.Reserved;
                }
            }

            this.Session.Remove("orderId");
            this.orders.Update(order);

            return this.RedirectToAction("Details", "Order", new { id = order.Id, area = string.Empty });
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

                return this.Json(new { success = true, error = string.Empty, productsCount = order == null ? 1 : order.Products.Count() });
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

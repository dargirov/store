namespace OnlineStore.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Product;
    using Web.Controllers;

    public class ProductController : BaseController
    {
        private readonly IProductsService products;
        private Random rand;

        public ProductController(IProductsService products)
        {
            this.products = products;
            this.rand = new Random();
        }

        public ActionResult Index(int id)
        {
            var viewModel = this.products.GetByCollectionId(id).To<IndexViewModel>();
            this.ViewBag.CollectionId = id;
            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var viewModel = new CreateViewModel()
            {
                CollectionId = id
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (model.File == null || model.File.ContentLength == 0)
            {
                this.ModelState.AddModelError("Image", "Upload image");
                return this.View(model);
            }

            var fileName = this.rand.Next(10000, 100000) + Path.GetFileName(model.File.FileName);
            var imagesList = new List<ProductImage>();
            var images = new ProductImage()
            {
                Name = fileName,
                ContentType = model.File.ContentType
            };

            imagesList.Add(images);

            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                IsActive = true,
                CollectionId = model.CollectionId,
                Variants = model.Variants.ToList(),
                Images = imagesList
            };

            var productId = this.products.Create(product);

            var newPath = GlobalConstants.AdminPathToProductImages + productId;
            bool exists = Directory.Exists(this.Server.MapPath(newPath));

            if (!exists)
            {
                Directory.CreateDirectory(this.Server.MapPath(newPath));
            }

            var path = Path.Combine(this.Server.MapPath(newPath), fileName);
            model.File.SaveAs(path);

            return this.RedirectToAction("Index", "Product", new { area = "Administration", id = model.CollectionId });
        }
    }
}

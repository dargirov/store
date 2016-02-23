namespace OnlineStore.Web.Areas.Administration.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Collection;
    using Web.Controllers;

    public class CollectionController : BaseController
    {
        private readonly ICollectionsService collections;
        private readonly ICategoriesService categories;
        private Random rand;

        public CollectionController(ICollectionsService collections, ICategoriesService categories)
        {
            this.collections = collections;
            this.categories = categories;
            this.rand = new Random();
        }

        public ActionResult Index(int id = 1)
        {
            var page = id;
            var allItemsCount = this.collections.Count();
            var itemsPerPage = GlobalConstants.AdminItemsPerPage;

            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)itemsPerPage);
            var itemsToSkip = (page - 1) * itemsPerPage;

            var collections = this.collections
                .GetAllWidthDeleted()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(itemsToSkip)
                .Take(itemsPerPage)
                .To<IndexViewModel>().ToList();

            this.ViewBag.CurrentPage = page;
            this.ViewBag.TotalPages = totalPages;

            return this.View(collections);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var categories = this.categories.GetAll().ToList();
            var viewModel = new CreateViewModel()
            {
                Categories = categories
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = this.categories.GetAll().ToList();
                return this.View(model);
            }

            if (model.File == null || model.File.ContentLength == 0)
            {
                model.Categories = this.categories.GetAll().ToList();
                this.ModelState.AddModelError("Image", "Upload image");
                return this.View(model);
            }

            var fileName = this.rand.Next(10000, 100000) + Path.GetFileName(model.File.FileName);

            var collectionId = this.collections.Create(
                model.Name,
                model.ShortDescription,
                model.Description,
                model.Discount,
                model.DateStart,
                model.DateEnd,
                model.CategoryId,
                fileName);

            var newPath = GlobalConstants.AdminPathToCollectionImages + collectionId;
            bool exists = Directory.Exists(this.Server.MapPath(newPath));

            if (!exists)
            {
                Directory.CreateDirectory(this.Server.MapPath(newPath));
            }

            var path = Path.Combine(this.Server.MapPath(newPath), fileName);
            model.File.SaveAs(path);

            return this.RedirectToAction("Index", "Collection", new { area = "Administration" });
        }

        public ActionResult Delete(int id)
        {
            this.collections.Delete(id);
            return this.RedirectToAction("Index", "Collection", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var categories = this.categories.GetAll().ToList();
            var collection = this.collections.GetById(id);

            var viewModel = this.Mapper.Map<CreateViewModel>(collection);
            viewModel.Categories = categories;

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateViewModel model)
        {
            var categories = this.categories.GetAll().ToList();
            var collection = this.collections.GetById(model.Id);

            if (!this.ModelState.IsValid)
            {
                model.Categories = categories;
                return this.View(model);
            }

            collection.Name = model.Name;
            collection.ShortDescription = model.ShortDescription;
            collection.Description = model.Description;
            collection.Discount = model.Discount;
            collection.DateStart = model.DateStart;
            collection.DateEnd = model.DateEnd;
            collection.CategoryId = model.CategoryId;
            collection.IsActive = model.IsActive;

            if (model.File != null && model.File.ContentLength > 0)
            {
                var fileName = this.rand.Next(10000, 100000) + Path.GetFileName(model.File.FileName);
                var newPath = GlobalConstants.AdminPathToCollectionImages + collection.Id;
                var path = Path.Combine(this.Server.MapPath(newPath), fileName);
                model.File.SaveAs(path);
                collection.Image = fileName;
            }

            this.collections.Update();

            this.TempData["updated"] = true;
            return this.RedirectToAction("Edit", "Collection", new { id = collection.Id });
        }
    }
}

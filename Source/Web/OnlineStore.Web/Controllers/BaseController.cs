namespace OnlineStore.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using Services.Web;

    public abstract class BaseController : Controller
    {
        private readonly ICategoriesService categories;

        public BaseController()
        {
        }

        public BaseController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected List<Category> GetCategories()
        {
            return this.categories.GetAll().ToList();
        }
    }
}

namespace OnlineStore.Web.Areas.Cart
{
    using System.Web.Mvc;

    public class CartAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get 
            {
                return "Cart";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CartRoute",
                "Cart/{controller}/{action}/{id}",
                new { controller = "Cart", action = "Index", id = UrlParameter.Optional });
        }
    }
}
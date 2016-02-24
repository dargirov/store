namespace OnlineStore.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Common;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
        public ActionResult Index()
        {
            return this.RedirectToAction("Index", "Collection", new { area = "Administration" });
        }
    }
}

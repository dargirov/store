namespace OnlineStore.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using OnlineStore.Common;
    using OnlineStore.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}

namespace OnlineStore.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class OrdersRouteTests
    {
        [Test]
        public void TestRootRoute()
        {
            const string Url = "/Order";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<OrderController>(c => c.Index());
        }

        [Test]
        public void TestRouteById()
        {
            const string Url = "/Order/Details/7";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<OrderController>(c => c.Details(7));
        }
    }
}

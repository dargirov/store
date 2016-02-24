namespace OnlineStore.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class CollectionsRouteTests
    {
        [Test]
        public void TestRouteByAcronym()
        {
            const string Url = "/Collection/nife-963";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<CollectionController>(c => c.Index("nife-963"));
        }
    }
}

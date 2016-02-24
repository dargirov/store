namespace OnlineStore.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;

    using Controllers;

    using NUnit.Framework;

    [TestFixture]
    public class ProductsRouteTests
    {
        [Test]
        public void TestRouteByAcronym()
        {
            const string Url = "/Product/елегантна-рокля-в-тъмносива-гама-от-nife-240";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ProductController>(c => c.Index("елегантна-рокля-в-тъмносива-гама-от-nife-240"));
        }
    }
}

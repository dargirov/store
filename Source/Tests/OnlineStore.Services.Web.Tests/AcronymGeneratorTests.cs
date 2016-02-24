namespace OnlineStore.Services.Web.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AcronymGeneratorTests
    {
        [Test]
        public void GenratedAcronymShouldMatchTheName()
        {
            const string Name = "Елегантна рокля в тъмносива гама от Nife";
            const string Acronym = "елегантна-рокля-в-тъмносива-гама-от-nife";
            var generator = new AcronymGenerator();
            var newAcronym = generator.Generate(Name);

            var lastDash = newAcronym.LastIndexOf("-");
            newAcronym = newAcronym.Substring(0, lastDash);

            Assert.AreEqual(Acronym, newAcronym);
        }
    }
}

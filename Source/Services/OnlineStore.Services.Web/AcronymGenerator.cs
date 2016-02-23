namespace OnlineStore.Services.Web
{
    using System;

    public class AcronymGenerator : IAcronymGenerator
    {
        public string Generate(string text)
        {
            Random rand = new Random();
            var acronym = text.ToLower();
            acronym = acronym.Replace(" ", "-");
            acronym = acronym.Replace(".", "-");
            acronym = acronym.Replace("_", "-");
            acronym += "-" + rand.Next(100, 1000).ToString();
            return acronym;
        }
    }
}

namespace OnlineStore.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            /*const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }*/

            //if (!context.Collections.Any())
            //{
            //    var categoryList = this.GenerateCategories(context);
            //    var collectionList = this.GenerateCollections(context, categoryList);
            //    var productList = this.GenerateProducts(context, collectionList);
            //    this.GenerateProductVariants(context, productList);
            //    this.GenerateCities(context);
            //}
        }

        private void GenerateCities(ApplicationDbContext context)
        {
            context.Cities.Add(new City() { Name = "София" });
            context.Cities.Add(new City() { Name = "Пловдив" });
            context.Cities.Add(new City() { Name = "Варна" });
            context.Cities.Add(new City() { Name = "Бургас" });
            context.Cities.Add(new City() { Name = "Русе" });
            context.Cities.Add(new City() { Name = "Видин" });
            context.Cities.Add(new City() { Name = "Асеновград" });
            context.Cities.Add(new City() { Name = "Смолян" });
            context.Cities.Add(new City() { Name = "Трявна" });
            context.Cities.Add(new City() { Name = "Перник" });
            context.Cities.Add(new City() { Name = "Плевен" });
            context.Cities.Add(new City() { Name = "Велико Търново" });
            context.SaveChanges();
        }

        private List<Category> GenerateCategories(ApplicationDbContext context)
        {
            var categoryList = new List<Category>();
            var category1 = new Category()
            {
                Name = "Дамска мода",
                IsActive = true,
                Acronym = this.GenerateAcronym("Дамска мода")
            };

            categoryList.Add(category1);
            context.Categories.Add(category1);

            var category2 = new Category()
            {
                Name = "Мъжка мода",
                IsActive = true,
                Acronym = this.GenerateAcronym("Мъжка мода")
            };

            categoryList.Add(category2);
            context.Categories.Add(category2);

            context.SaveChanges();
            return categoryList;
        }

        private List<Collection> GenerateCollections(ApplicationDbContext context, List<Category> categoryList)
        {
            var collectionList = new List<Collection>();
            var collection1 = new Collection()
            {
                Name = "Agel Knitwear",
                Acronym = "agel-knitwear",
                ShortDescription = "Моден оазис за ценителите на стилния комфорт!",
                Description = "Agel Knitwear е емоция, която Ви обгръща и пленява. Духът на популярния бранд е жив, динамичен и експресивен. Невероятните материи и прецизни дизайни на бранда спомагат за незаменимото усещане на комфорт и удобство по всяко време. Великолепно издържани визии, гарнирани със стил и уют. Това е Agel Knitwear!",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(10),
                IsActive = true,
                Discount = 56,
                CategoryId = categoryList[0].Id,
                Image = "http://www.secretzone.bg/static/gfx/collections/1455881624_460x230.jpg"
            };

            collectionList.Add(collection1);
            context.Collections.Add(collection1);

            var collection2 = new Collection()
            {
                Name = "Mangotti",
                Acronym = "mangotti",
                ShortDescription = "Изискано модно съвършенство, подчертано със стил! - Пролет/Лято 2016",
                Description = "Непоколебимото присъствие, с което уверената дама подчертава женствеността и интелигентния си нрав са на път да Ви възхитят с колекцията на Mangotti. Дързък шик и буден вътрешен свят са посланията, които моделите изпращат на околните. Брандът величае класата и равенството на жената в свят на себедоказване и утвърждаване.",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(15),
                IsActive = true,
                Discount = 64,
                CategoryId = categoryList[0].Id,
                Image = "http://www.secretzone.bg/static/gfx/collections/1455808261_460x230.jpg"
            };

            collectionList.Add(collection2);
            context.Collections.Add(collection2);

            var collection3 = new Collection()
            {
                Name = "Gant & Hugo Boss",
                Acronym = "gant-hugo-boss",
                ShortDescription = "Примерен и хармоничен мъжки вкус за семпла и стилна визия!",
                Description = "Gant & Hugo Boss представят една колекция, богата на полезни предложения в сферата на мъжката първокласна мода. Добър вкус, изчистен дизайн и елегантни съчетания. Брандовете си позволяват да експериментират с цветовете, докато разчитат на класическите форми.",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(20),
                IsActive = true,
                Discount = 72,
                CategoryId = categoryList[1].Id,
                Image = "http://www.secretzone.bg/static/gfx/collections/1455705388_460x230.jpg"
            };

            collectionList.Add(collection3);
            context.Collections.Add(collection3);

            context.SaveChanges();
            return collectionList;
        }

        private List<Product> GenerateProducts(ApplicationDbContext context, List<Collection> collectionList)
        {
            var productList = new List<Product>();

            var product1 = new Product()
            {
                Name = "Жилетка с цип от Agel Knitwear в пясъчен нюанс",
                Acronym = this.GenerateAcronym("Жилетка с цип от Agel Knitwear в пясъчен нюанс"),
                CollectionId = collectionList[0].Id,
                Description = "Жилетка с цип от Agel Knitwear в пясъчен нюанс\nУдобна качулка\nПрилеп ръкави\nЗатваряне с цип\nЛого на марката\nМатериал: 70 % Дралон, 30 % Вълна\nКод на продукта: 534725\nДоставка: Европейски съюз",
                IsActive = true
            };

            productList.Add(product1);
            context.Products.Add(product1);

            context.SaveChanges();
            return productList;
        }

        private void GenerateProductVariants(ApplicationDbContext context, List<Product> productList)
        {
            var variant1 = new ProductVariant()
            {
                Internal = "S",
                Supplier = "S",
                PriceCustomer = 100,
                PriceMrsp = 150,
                ProductId = productList[0].Id,
                Quantity = 10,
                Reserved = 0
            };

            context.ProductVariants.Add(variant1);

            var variant2 = new ProductVariant()
            {
                Internal = "M",
                Supplier = "M",
                PriceCustomer = 100,
                PriceMrsp = 150,
                ProductId = productList[0].Id,
                Quantity = 5,
                Reserved = 0
            };

            context.ProductVariants.Add(variant2);

            context.SaveChanges();
        }

        private string GenerateAcronym(string name)
        {
            var acronym = name.ToLower();
            acronym = acronym.Replace(" ", "-");
            acronym = acronym.Replace(".", "-");
            acronym = acronym.Replace("_", "-");
            return acronym;
        }
    }
}

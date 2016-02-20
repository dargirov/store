namespace OnlineStore.Web.ViewModels.Collection
{
    using Infrastructure.Mapping;

    public class VariantViewModel : IMapFrom<Data.Models.ProductVariant>
    {
        public string Internal { get; set; }

        public decimal PriceCustomer { get; set; }

        public decimal PriceMrsp { get; set; }
    }
}

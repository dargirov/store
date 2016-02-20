namespace OnlineStore.Web.ViewModels.Product
{
    using Infrastructure.Mapping;

    public class VariantViewModel : IMapFrom<Data.Models.ProductVariant>
    {
        public string Internal { get; set; }

        public decimal PriceCustomer { get; set; }

        public decimal PriceMrsp { get; set; }

        public int Quantity { get; set; }

        public int Reserved { get; set; }
    }
}
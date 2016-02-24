namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class ProductVariant : BaseModel<int>
    {
        [Required]
        [MaxLength(30)]
        public string Internal { get; set; }

        [Required]
        [MaxLength(30)]
        public string Supplier { get; set; }

        [Required]
        public decimal PriceCustomer { get; set; }

        [Required]
        public decimal PriceMrsp { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Reserved { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}

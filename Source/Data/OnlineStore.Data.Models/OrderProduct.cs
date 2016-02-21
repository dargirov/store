namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class OrderProduct : BaseModel<int>
    {
        [Required]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        [Range(1, 100)]
        public int Reserved { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public int ProductVariantId { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }
    }
}

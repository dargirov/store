namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using OnlineStore.Data.Common.Models;

    public class ProductImage : BaseModel<int>
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContentType { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}

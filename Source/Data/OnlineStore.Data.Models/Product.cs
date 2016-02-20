namespace OnlineStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Product : BaseModel<int>
    {
        public Product()
        {
            this.Variants = new HashSet<ProductVariant>();
            this.Images = new HashSet<ProductImage>();
        }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(210)]
        [Index(IsUnique = true)]
        public string Acronym { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int CollectionId { get; set; }

        public virtual Collection Collection { get; set; }

        public virtual ICollection<ProductVariant> Variants { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; }
    }
}

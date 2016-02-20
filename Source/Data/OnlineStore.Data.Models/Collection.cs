namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using OnlineStore.Data.Common.Models;

    public class Collection : BaseModel<int>
    {
        public Collection()
        {
            this.Products = new HashSet<Product>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(110)]
        public string Acronym { get; set; }

        [Required]
        [MaxLength(300)]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [MaxLength(200)]
        public string Image { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Discount { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

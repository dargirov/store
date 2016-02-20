namespace OnlineStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using OnlineStore.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Collections = new HashSet<Collection>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(60)]
        public string Acronym { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
    }
}

namespace OnlineStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Address : BaseModel<int>
    {
        public Address()
        {
            this.Cities = new HashSet<City>();
        }

        public virtual ICollection<City> Cities { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        public string Comment { get; set; }
    }
}

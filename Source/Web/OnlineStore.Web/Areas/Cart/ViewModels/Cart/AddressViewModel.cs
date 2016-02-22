namespace OnlineStore.Web.Areas.Cart.ViewModels.Cart
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AddressViewModel : IMapFrom<Address>
    {
        [Display(Name = "Град")]
        public IEnumerable<City> Cities { get; set; }

        public int? CityId { get; set; }

        public City City { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Улица")]
        public string Street { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Коментар")]
        public string Comment { get; set; }
    }
}

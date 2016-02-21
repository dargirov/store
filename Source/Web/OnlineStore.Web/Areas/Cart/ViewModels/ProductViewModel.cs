namespace OnlineStore.Web.Areas.Cart.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel
    {
        [Required]
        public string Acronym { get; set; }

        [Required]
        public string Internal { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}

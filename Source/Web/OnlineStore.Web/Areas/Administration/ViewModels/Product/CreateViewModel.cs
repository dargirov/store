namespace OnlineStore.Web.Areas.Administration.ViewModels.Product
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateViewModel : IMapFrom<Product>
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [UIHint("TextArea")]
        [Required]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int CollectionId { get; set; }

        public IEnumerable<ProductVariant> Variants { get; set; }

        public IEnumerable<ProductImage> Images { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}

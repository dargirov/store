namespace OnlineStore.Web.Areas.Administration.ViewModels.Collection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateViewModel : IMapFrom<Collection>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Кратко описание")]
        public string ShortDescription { get; set; }

        [Required]
        [UIHint("TextArea")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "Намаление")]
        public decimal Discount { get; set; }

        [Required]
        [Display(Name = "Начална дата")]
        public DateTime DateStart { get; set; }

        [Required]
        [Display(Name = "Крайна дата")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Изображение")]
        public string Image { get; set; }

        public HttpPostedFileBase File { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; }

        [Display(Name = "Активна")]
        public bool IsActive { get; set; }
    }
}

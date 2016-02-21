namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class City : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}

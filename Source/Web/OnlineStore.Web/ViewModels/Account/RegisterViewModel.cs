namespace OnlineStore.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email адрес е задължително поле")]
        [EmailAddress(ErrorMessage = "Невалиден Email адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Парола е задължително поле")]
        [StringLength(100, ErrorMessage = "Паролата трябва да бъде с минимална дължина от {2} символа", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторете паролата")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Име е задължително поле")]
        [MaxLength(50)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия е задължително име")]
        [MaxLength(50)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}

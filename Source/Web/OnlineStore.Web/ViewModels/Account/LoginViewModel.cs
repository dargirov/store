namespace OnlineStore.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email адрес е задължително поле")]
        [Display(Name = "Email адрес")]
        [EmailAddress(ErrorMessage = "Невалиден Email адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Парола е задължително поле")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }
}

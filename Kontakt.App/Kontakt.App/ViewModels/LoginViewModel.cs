

using System.ComponentModel.DataAnnotations;

namespace Kontakt.App.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       public bool isRememberMe { get; set; }

    }
}

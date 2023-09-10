
using Kontakt.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Kontakt.App.ViewModels
{
    public class UserUpdateViewModel
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public string? PhoneNumber { get; set; }
        public bool IsCheckbox1Checked { get; set; }

        [RequiredIf("IsCheckbox1Checked", true, ErrorMessage = "This field is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [RequiredIf("IsCheckbox1Checked", true, ErrorMessage = "This field is required.")]
        public string? CurrentPassword { get; set; }
        public bool IsCheckbox2Checked { get; set; }

        [RequiredIf("IsCheckbox2Checked", true, ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [RequiredIf("IsCheckbox2Checked", true, ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }


    }
}

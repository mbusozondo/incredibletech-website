using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace INCREDIBLE_TECH__LTD_.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

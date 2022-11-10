using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace INCREDIBLE_TECH__LTD_.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}

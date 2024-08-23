using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}

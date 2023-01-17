using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace JuanMVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Fullname { get; set; }
        [Required]

        [StringLength(maximumLength: 50)]
        public string Username { get; set; }
        [Required]

        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MinLength(8)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}

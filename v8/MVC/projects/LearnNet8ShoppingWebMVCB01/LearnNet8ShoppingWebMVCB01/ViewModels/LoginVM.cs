using System.ComponentModel.DataAnnotations;

namespace LearnNet8ShoppingWebMVCB01.ViewModels
{
	public class LoginVM
	{
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is not empty")]
        [MaxLength(20, ErrorMessage = "Maximum 20 characters.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is not empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

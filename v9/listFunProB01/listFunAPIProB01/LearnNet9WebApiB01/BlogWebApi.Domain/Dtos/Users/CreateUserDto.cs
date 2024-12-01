using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Dtos.Users
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        public string Password { get; set; }
        public string Fullname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        [Required(ErrorMessage = "Role Id is required!")]
        public Guid RoleId { get; set; }
    }
}

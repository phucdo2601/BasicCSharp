using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApi.Application.Dtos
{
    public  record GetUserDto(
        [Required] string Name,
        [Required] string TelephoneNumber,
        [Required] string Address,
        [Required, EmailAddress] string Email,
        [Required] string Password,
        [Required] string Role
        );
}

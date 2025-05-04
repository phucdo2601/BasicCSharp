using AuthApi.Application.Dtos;
using eCommerce.SharedLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApi.Application.Interfaces
{
    public interface IUser
    {
        Task<Response> Register(AppUserDto appUserDto);
        Task<Response> Login(LoginDto loginDto);
        Task<GetUserDto> GetUser(int userId);
    }
}

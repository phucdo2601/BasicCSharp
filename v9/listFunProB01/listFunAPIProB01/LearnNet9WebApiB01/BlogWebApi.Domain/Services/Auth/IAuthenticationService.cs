using BlogWebApi.Domain.Dtos.Authentications;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Auth
{
    public interface IAuthenticationService : IGenericService<UserEntity>
    {
        UserEntity RegisterUser(UserEntity user);

        UserEntity Login(LoginDto model);

        Task<UserEntity> LoginAsync(LoginDto model);

        Task<UserEntity> RegisterUserAsync(UserEntity user);
    }
}

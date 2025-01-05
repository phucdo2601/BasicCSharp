using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos.Authentications;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Domain.Services.Users;
using BlogWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Auth
{
    public class AuthenticationService : GenericService<UserEntity>, IAuthenticationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserEntity> _genericRepository;

        public AuthenticationService(ApplicationDbContext context, IUnitOfWork unitOfWork, IGenericRepository<UserEntity> repository) : base(context, unitOfWork, repository)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _genericRepository = repository;
        }

        public UserEntity Login(LoginDto model)
        {
            try
            {
                UserEntity user = _genericRepository.FindByConditions(p => p.Username == model.Username && p.Password == model.Password).SingleOrDefault();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserEntity> LoginAsync(LoginDto model)
        {
            try
            {
                //UserEntity user = await _genericRepository.FindByConditions(p => p.Username == model.Username && p.Password == model.Password).SingleOrDefault();
                return null;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        public UserEntity RegisterUser(UserEntity user)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _genericRepository.Add(user);
                    int created = _unitOfWork.Save();
                    transaction.Commit();
                    user = _genericRepository.FindById(user.Id);
                    return user;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    _unitOfWork.Dispose();
                }
            }
        }

        public Task<UserEntity> RegisterUserAsync(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}

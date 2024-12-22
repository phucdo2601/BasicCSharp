using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Domain.Services.Generics
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;
        private readonly ApplicationDbContext _context;

        public GenericService(ApplicationDbContext context, IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public T Create(T entity)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _repository.Add(entity);
                    int created = _unitOfWork.Save();
                    transaction.Commit();
                    entity = _repository.FindById(entity.Id);
                    return entity;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return null;
                }
                finally
                {
                    _unitOfWork.Dispose();
                }
            }

        }

        public bool Delete(T entity)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _repository.Remove(entity);
                    int saved = _unitOfWork.Save();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
                finally
                {
                    _unitOfWork.Dispose();
                }
            }
        }

        public IEnumerable<T> FindAll()
        {
            try
            {
                var listVals = _repository.FindAll();
                return listVals;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        public IEnumerable<T> FindByConditions(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var listVals = _repository.FindByConditions(predicate);
                return listVals;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        public T FindById(Guid id)
        {
            try
            {
                T objRe;
                objRe = _repository.FindById(id);
                return objRe;
            }
            catch (Exception)
            {

                throw;
            }
            finally { _unitOfWork.Dispose(); }
        }



        public T Update(T entity)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _repository.Update(entity);
                    int save = _unitOfWork.Save();
                    transaction.Commit();
                    entity = _repository.FindById(entity.Id);
                    return entity;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return null;
                }
                finally
                {
                    _unitOfWork.Dispose();
                }
            }
        }
    }
}

using PracNet7ApiProB01.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Infrastructures
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly PracNet7ApiDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        public GenericService(PracNet7ApiDbContext _context, IUnitOfWork _unitOfWork, IGenericRepository<T> _repository)
        {
            this._context = _context;
            this._unitOfWork = _unitOfWork;
            this._repository = _repository;
        }

        #region Find All
        public List<T> FindAll()
        {

            try
            {
                List<T> listData = _repository.FindAll().ToList();
                return listData;
            }
            catch (Exception)
            {

                throw;
            }
            finally { _unitOfWork.Dispose(); }
        }
        #endregion

        #region FindById
        public T FindById(Guid id)
        {
            try
            {
                var item = _repository.FindById(id);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
            finally { _unitOfWork?.Dispose(); }
        }
        #endregion

    }
}

using PracNet7ApiProB01.Dto.Dtos.Product;
using PracNet7ApiProB01.Dto.Dtos.ProductBrand;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using PracNet7ApiProB01.Utils.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Services.EntityServices.ProductService
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly PracNet7ApiDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product> _repository;
        private readonly ModelMapperConfig _modelMapperConfig;
        public ProductService(PracNet7ApiDbContext _context, IUnitOfWork _unitOfWork, IGenericRepository<Product> _repository, ModelMapperConfig _) : base(_context, _unitOfWork, _repository)
        {
            this._context = _context;
            this._unitOfWork = _unitOfWork;
            this._repository = _repository;
        }

        #region CreateNewProduct
        public async Task<object> CreateNewProduct(CreateProductBrandReqDto model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // TODO: VALIDATE ALL FIELDS NECCESSARY

                    var Id = Guid.NewGuid();

                    /**
                     * set up auto mapping from input to entity
                     * from: CreateProductReqDto
                     * to: Product
                     */



                    return null
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
        }
        #endregion

        #region DeleteProduct
        public Task<object> DeleteProduct(string productId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UpdateProduct
        public Task<object> UpdateProduct(UpdateProductReqDto model)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

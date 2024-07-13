using PracNet7ApiProB01.Dto.Dtos.Product;
using PracNet7ApiProB01.Dto.Dtos.ProductBrand;
using PracNet7ApiProB01.Dto.Dtos.Responses;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using PracNet7ApiProB01.Utils.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Services.EntityServices.ProductService
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly PracNet7ApiDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product> _repository;
        public ProductService(PracNet7ApiDbContext _context, IUnitOfWork _unitOfWork, IGenericRepository<Product> _repository) : base(_context, _unitOfWork, _repository)
        {
            this._context = _context;
            this._unitOfWork = _unitOfWork;
            this._repository = _repository;
        }

        #region CreateNewProduct
        public async Task<object> CreateNewProduct(CreateProductReqDto model)
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

                    var _modelMapperConfig = ModelMapperConfig.IniializeAutoMapper();
                    var productEntity = _modelMapperConfig.Map<CreateProductReqDto, Product>(model);
                    productEntity.Id = Id;
                    _unitOfWork.ProductRepository.CreateNew(productEntity);
                    int created = _unitOfWork.Save();
                    transaction.Commit();

                    var productCreated = _repository.FindById(Id);

                    return await Task.FromResult(
                        new CommonResponseDto<Product>
                        {
                            Status = HttpStatusCode.Created.ToString(),
                            Message = $"Add Product successfully!",
                        }
                        );

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally { _unitOfWork.Dispose(); }
            }
            
        }
        #endregion

        #region DeleteProduct
        public async Task<object> DeleteProduct(string productId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Guid productUuid = Guid.Parse(productId);
                    var product = _repository.FindById(productUuid);
                    if (product == null)
                    {
                        return await Task.FromResult(new CommonResponseDto<Product>
                        {
                            Status = HttpStatusCode.BadRequest.ToString(),
                            Message = $"Product does not existed"
                        });
                    }
                    else
                    {
                        _unitOfWork.ProductRepository.Delete(product);
                        int deleted = _unitOfWork.Save();
                        transaction.Commit();
                        return await Task.FromResult(new CommonResponseDto<Product>
                        {
                            Status = HttpStatusCode.OK.ToString(),
                            Message = $"Product deleted successfully!",
                            StatusCode = 200,
                        });
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback( );
                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }
        #endregion

        #region UpdateProduct
        public async Task<object> UpdateProduct(string productId, UpdateProductReqDto model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Guid productUUid = Guid.Parse(productId);

                    if (!productUUid.Equals(model.Id)) {
                        return await Task.FromResult(new CommonResponseDto<Product>
                        {
                            Status = HttpStatusCode.BadRequest.ToString(),
                            Message = $"Id in update model and id param does not match"
                        });
                    }

                    var product = _unitOfWork.ProductRepository.FindById(productUUid);

                    if (product == null)
                    {
                        return await Task.FromResult(new CommonResponseDto<Product>
                        {
                            Status = HttpStatusCode.BadRequest.ToString(),
                            Message = $"Product does not existed"
                        });
                    }

                    // TODO: VALIDATE ALL FIELDS NECESSARY

                    /**
                     * set up auto mapping from input to entity
                     * from: CreateProductReqDto
                     * to: Product
                     */
                    var _modelMapperConfig = ModelMapperConfig.IniializeAutoMapper();
                    product = _modelMapperConfig.Map<UpdateProductReqDto, Product>(model);
                    int updated = _unitOfWork.Save();
                    transaction.Commit();

                    var productUpdated = _repository.FindById(model.Id);
                    return await Task.FromResult(new CommonResponseDto<Product>
                    {
                        Status = HttpStatusCode.Created.ToString(),
                        Message = $"Update product successfully!",
                        Data = productUpdated,
                    });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    _context.Dispose();
                }
            }
        }
        #endregion
    }
}

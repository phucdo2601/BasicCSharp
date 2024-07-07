using PracNet7ApiProB01.Dto.Dtos.ProductBrand;
using PracNet7ApiProB01.Dto.Dtos.Responses;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Services.EntityServices.ProductBrandService
{
    public class ProductBrandService : GenericService<ProductBrand>, IProductBrandService
    {
        private readonly PracNet7ApiDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<ProductBrand> _repository;
        public ProductBrandService(PracNet7ApiDbContext _context, IUnitOfWork _unitOfWork, IGenericRepository<ProductBrand> _repository) : base(_context, _unitOfWork, _repository)
        {
            this._context = _context;
            this._unitOfWork = _unitOfWork;
            this._repository = _repository;
        }

        #region CreateNewProductBrand
        
        public async Task<object> CreateNewProductBrand(CreateProductBrandReqDto model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // TODO: VALIDATE ALL FIELDS NECESSARY

                    var Id = Guid.NewGuid();

                    ProductBrand productBrand = new ProductBrand()
                    {
                        Id = Id,
                        BrandCode = model.BrandCode,
                        BrandNName = model.BrandNName,
                        DateOfCreate = DateTime.Now,
                        DateOfUpdate = null,
                        Description = model.Description,
                    };
                    _unitOfWork.ProductBrandRepository.CreateNew(productBrand);
                    int created = _unitOfWork.Save();
                    transaction.Commit();

                    var proBrandCreated = _repository.FindById(Id);
                    return await Task.FromResult(new CommonResponseDto<ProductBrand>
                    {
                        Status = HttpStatusCode.Created.ToString(),
                        Message = $"Add product brand successfully!",
                        Data = proBrandCreated,
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

        #region DeleteProductBrand
        public async Task<object> DeleteProductBrand(string productBrandId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Guid productBrandUuid = Guid.Parse(productBrandId);
                    var productBrand = _repository.FindById(productBrandUuid);
                    if (productBrand == null)
                    {
                        return await Task.FromResult(new CommonResponseDto<ProductBrand>
                        {
                            Status = HttpStatusCode.BadRequest.ToString(),
                            Message = $"Product Brand does not existed"
                        });
                    }
                    else
                    {
                        _unitOfWork.ProductBrandRepository.Delete(productBrand);
                        int deleted = _unitOfWork.Save();
                        transaction.Commit();
                        return await Task.FromResult(new CommonResponseDto<ProductBrand>
                        {
                            Status = HttpStatusCode.OK.ToString(),
                            Message = $"Product Brand deleted successfully!",
                            StatusCode = 200,
                        });
                    }
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
        #endregion

        #region UpdateProductBrand
        public async Task<object> UpdateProductBrand(string productBrandId, UpdateProductBrandReqDto model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Guid productBrandUuid = Guid.Parse(productBrandId);

                    if (!productBrandUuid.Equals(model.Id))
                    {
                        return await Task.FromResult(new CommonResponseDto<ProductBrand>
                        {
                            Status = HttpStatusCode.BadRequest.ToString(),
                            Message = $"Id in update model and id param does not match"
                        });
                    }

                    var productBrand = _unitOfWork.ProductBrandRepository.FindById(productBrandUuid);

                    if (productBrand == null)
                    {
                        return await Task.FromResult(new CommonResponseDto<ProductBrand>
                        {
                            Status = HttpStatusCode.BadRequest.ToString(),
                            Message = $"Product Brand does not existed"
                        });
                    }
                    // TODO: VALIDATE ALL FIELDS NECESSARY

                    productBrand.DateOfUpdate = DateTime.Now;
                    productBrand.BrandNName = model.BrandNName;
                    productBrand.BrandCode = model.BrandCode;
                    productBrand.Description = model.Description;

                    _unitOfWork.ProductBrandRepository.Update(productBrand);
                    int updated = _unitOfWork.Save();
                    transaction.Commit();

                    var productBrandUpdated = _repository.FindById(productBrandUuid);
                    return await Task.FromResult(new CommonResponseDto<ProductBrand>
                    {
                        Status = HttpStatusCode.Created.ToString(),
                        Message = $"Update product brand successfully!",
                        Data = productBrandUpdated,
                    });
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
        #endregion
    }
}

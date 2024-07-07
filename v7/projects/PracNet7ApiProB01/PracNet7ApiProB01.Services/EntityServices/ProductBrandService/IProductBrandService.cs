using PracNet7ApiProB01.Dto.Dtos.ProductBrand;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Services.EntityServices.ProductBrandService
{
    public interface IProductBrandService : IGenericService<ProductBrand>
    {
        #region CreateNewProductBrand
        Task<object> CreateNewProductBrand(CreateProductBrandReqDto model);
        #endregion

        #region UpdateProductBrand
        Task<object> UpdateProductBrand(string productBrandId, UpdateProductBrandReqDto model);
        #endregion

        #region DeleteProductBrand
        Task<object> DeleteProductBrand(string productBrandId);
        #endregion

    }
}

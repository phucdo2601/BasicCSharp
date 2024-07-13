using PracNet7ApiProB01.Dto.Dtos.Product;
using PracNet7ApiProB01.Dto.Dtos.ProductBrand;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Services.EntityServices.ProductService
{
    public interface IProductService : IGenericService<Product>
    {
        #region CreateNewProduct
        Task<object> CreateNewProduct(CreateProductReqDto model);
        #endregion

        #region UpdateProduct
        Task<object> UpdateProduct(string productId, UpdateProductReqDto model);
        #endregion

        #region DeleteProduct
        Task<object> DeleteProduct(string productId);
        #endregion

    }
}

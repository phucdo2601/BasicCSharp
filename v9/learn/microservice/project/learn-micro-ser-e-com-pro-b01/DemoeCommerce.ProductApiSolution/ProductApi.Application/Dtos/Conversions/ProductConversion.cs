using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Dtos.Conversions
{
    public static class ProductConversion
    {
        public static Product ToEntity(ProductDto product)
        {
            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price
            };
        }

        public static (ProductDto?, IEnumerable<ProductDto>?) FromEntity(Product product, IEnumerable<Product>? products)
        {
            // return single
            if (product is not null || products is null)
            {
                var singleProduct = new ProductDto(
                    product!.Id,
                    product.Name!,
                    product.Quantity,
                    product.Price
                    );

                return (singleProduct, null);
            }

            // return list
            if (products is not null || product is null)
            {
                var listProducts = products!.Select(pDto =>
                new ProductDto(
                        pDto.Id,
                        pDto.Name,
                        pDto.Quantity,
                        pDto.Price
                        )).ToList();

                return (null, listProducts);
            }

            return (null, null);
        }
    }
}

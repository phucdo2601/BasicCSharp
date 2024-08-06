using AutoMapper;
using PracNet7ApiProB01.Dto.Dtos.Product;
using PracNet7ApiProB01.Dto.Dtos.ProductBrand;
using PracNet7ApiProB01.Dto.Dtos.StaffRole;
using PracNet7ApiProB01.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Utils.Configs
{
    public class ModelMapperConfig
    {
        public static Mapper IniializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateProductReqDto, Product>();
                cfg.CreateMap<UpdateProductReqDto, Product>();
                cfg.CreateMap<CreateProductBrandReqDto, ProductBrand>();
                cfg.CreateMap<UpdateProductBrandReqDto, ProductBrand>();
                cfg.CreateMap<CreateStaffRoleReqDto, StaffRole>();
                cfg.CreateMap<UpdateStaffRoleReqDto, StaffRole>();
            });

            //Create an Instance of Mapper and return that instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}

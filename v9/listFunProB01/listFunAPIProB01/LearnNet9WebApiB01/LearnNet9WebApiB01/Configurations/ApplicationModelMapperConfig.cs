using AutoMapper;
using BlogWebApi.Domain.Dtos.BlogCategoríes;
using BlogWebApi.Model.Entities;

namespace BlogWebApi.Presentation.Configurations
{
    public class ApplicationModelMapperConfig : Profile
    {
        public ApplicationModelMapperConfig()
        {
            // Map BlogCategoryEntity to BlogCategoryDto (for customers)
            // Source: BlogCategoryEntity and Destination: BlogCategoryDto
            CreateMap<BlogCategoryEntity, BlogCategoryDto>();
            // Map CreateBlogCategoryDto to BlogCategoryEntity (for adding new Blog Category)
            // Source: CreateBlogCategoryDto and Destination: BlogCategoryEntity
            CreateMap<CreateBlogCategoryDto, BlogCategoryEntity>();
        }
    }
}

using AutoMapper;
using BlogWebApi.Domain.Dtos.BlogCategoríes;
using BlogWebApi.Domain.Dtos.Blogs;
using BlogWebApi.Domain.Dtos.Users;
using BlogWebApi.Model.Entities;

namespace BlogWebApi.Presentation.Configurations
{
    public class ApplicationModelMapperConfig : Profile
    {
        public ApplicationModelMapperConfig()
        {
            #region BlogCategoryEntity
            // Map BlogCategoryEntity to BlogCategoryDto 
            // Source: BlogCategoryEntity and Destination: BlogCategoryDto
            CreateMap<BlogCategoryEntity, BlogCategoryDto>();
            // Map CreateBlogCategoryDto to BlogCategoryEntity (for adding new Blog Category)
            // Source: CreateBlogCategoryDto and Destination: BlogCategoryEntity
            CreateMap<CreateBlogCategoryDto, BlogCategoryEntity>();
            #endregion


            #region BlogEntity
            // Map BlogEntity to BlogDto 
            // Source: BlogEntity and Destination: BlogDto
            CreateMap<BlogEntity, BlogDto>();
            // Map BlogCreateDto to BlogEntity (for adding new Blog)
            // Source: BlogCreateDto and Destination: BlogEntity
            CreateMap<BlogCreateDto, BlogEntity>();

            // Map BlogUpdateDto to BlogEntity (for update Blog)
            // Source: BlogUpdateDto and Destination: BlogEntity
            CreateMap<BlogUpdateDto, BlogEntity>();
            #endregion

            #region UserEntity
            // Map UserEntity to UserDto 
            // Source: UserEntity and Destination: UserDto
            CreateMap<UserEntity, UserDto>();
            // Map CreateUserDto to UserEntity (for adding new user)
            // Source: CreateUserDto and Destination: UserEntity
            CreateMap<CreateUserDto, UserEntity>();
            // Map UpdateUserDto to UserEntity (for update user)
            // Source: UpdateUserDto and Destination: UserEntity
            CreateMap<UpdateUserDto, UserEntity>();
            #endregion
        }
    }
}

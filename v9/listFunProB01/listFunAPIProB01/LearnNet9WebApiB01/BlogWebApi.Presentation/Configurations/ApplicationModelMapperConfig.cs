using AutoMapper;
using BlogWebApi.Domain.Dtos.BlogCategoríes;
using BlogWebApi.Domain.Dtos.Blogs;
using BlogWebApi.Domain.Dtos.Comments;
using BlogWebApi.Domain.Dtos.Interactions;
using BlogWebApi.Domain.Dtos.InteractionTypes;
using BlogWebApi.Domain.Dtos.Likes;
using BlogWebApi.Domain.Dtos.Shares;
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

            #region InteractionTypeEntity
            // Map InteractionTypeEntity to InteractionTypeDto 
            // Source: InteractionTypeEntity and Destination: InteractionTypeDto
            CreateMap<InteractionTypeEntity, InteractionTypeDto>();
            // Map CreateInteractionTypeDto to InteractionTypeEntity (for adding new interaction type)
            // Source: CreateInteractionTypeDto and Destination: InteractionTypeEntity
            CreateMap<CreateInteractionTypeDto, InteractionTypeEntity>();
            // Map UpdateInteractionTypeDto to InteractionTypeEntity (for update interaction type)
            // Source: UpdateInteractionTypeDto and Destination: InteractionTypeEntity
            CreateMap<UpdateInteractionTypeDto, InteractionTypeEntity>();
            #endregion

            #region InteractionEntity
            // Map InteractionEntity to InteractionDto 
            // Source: InteractionEntity and Destination: InteractionDto
            CreateMap<InteractionEntity, InteractionDto>();
            // Map CreateInteractionTypeDto to InteractionEntity (for adding new interaction)
            // Source: CreateInteractionTypeDto and Destination: InteractionEntity
            CreateMap<CreateInteractionDto, InteractionEntity>();
            // Map UpdateInteractionDto to InteractionEntity (for update interaction)
            // Source: UpdateInteractionDto and Destination: InteractionEntity
            CreateMap<UpdateInteractionDto, InteractionEntity>();
            #endregion

            #region LikeEntity
            // Map LikeEntity to LikeDto 
            // Source: LikeEntity and Destination: LikeDto
            CreateMap<LikeEntity, LikeDto>();
            // Map CreateLikeDto to LikeEntity (for adding new like)
            // Source: CreateLikeDto and Destination: LikeEntity
            CreateMap<CreateLikeDto, LikeEntity>();
            // Map UpdateLikeDto to LikeEntity (for update Like)
            // Source: UpdateLikeDto and Destination: LikeEntity
            CreateMap<UpdateLikeDto, LikeEntity>();
            #endregion

            #region ShareEntity
            // Map ShareEntity to ShareDto 
            // Source: ShareEntity and Destination: ShareDto
            CreateMap<ShareEntity, ShareDto>();
            // Map CreateShareDto to ShareEntity (for adding new share)
            // Source: CreateShareDto and Destination: ShareEntity
            CreateMap<CreateShareDto, ShareEntity>();
            // Map UpdateShareDto to ShareDto (for update share)
            // Source: UpdateShareDto and Destination: ShareDto
            CreateMap<UpdateShareDto, ShareDto>();
            #endregion

            #region CommentEntity
            // Map CommentEntity to CommentDto 
            // Source: CommentEntity and Destination: CommentDto
            CreateMap<CommentEntity, CommentDto>();
            // Map CreateCommonDto to CommentEntity (for adding new comment)
            // Source: CreateCommonDto and Destination: CommentEntity
            CreateMap<CreateCommonDto, CommentEntity>();
            // Map UpdateCommentDto to CommentEntity (for update comment)
            // Source: UpdateCommentDto and Destination: CommentEntity
            CreateMap<UpdateCommentDto, CommentEntity>();
            #endregion
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogWebApi.Application.Repositories.BlogRepository;
using BlogWebApi.Application.Repositories.CommentEntityRepository;
using BlogWebApi.Application.Repositories.UserEntityRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos.Comments;
using BlogWebApi.Domain.Services.Comments;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CommentController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentService _commentService;

        public CommentController(IUnitOfWork unitOfWork, ApplicationDbContext context, ILogger<CommentController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _userRepository = new UserRepository(_context);
            _blogRepository = new BlogRepository(_context);
            _commentRepository = new CommentRepository(_context);
            _commentService = new CommentService(_context, _unitOfWork, _commentRepository);
        }

        [HttpGet("getAllComments")]
        public async Task<IActionResult> GetAllComments()
        {
            _logger.LogInformation($"Begin {nameof(GetAllComments)} function in {this.GetType().Name}");
            IEnumerable<CommentEntity> listComments = _commentService.FindAll();
            if (listComments.Count() >= 0)
            {
                _logger.LogInformation($"Loading list data of {nameof(GetAllComments)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, listComments));
            }
            _logger.LogError($"Not Load list data of {nameof(GetAllComments)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = "Not Found all comments in the system" }));
        }

        [HttpGet("getCommentById/{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute(Name = "id")] string id)
        {
            _logger.LogInformation($"Begin {nameof(GetCommentById)} function in {this.GetType().Name}");
            try
            {
                var commentById = _commentService.FindById(Guid.Parse(id));
                if (commentById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(GetCommentById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, commentById));
                }
                _logger.LogError($"Not Load data of {nameof(GetCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Comment with id {id}" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(GetCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpGet("getListCommentsByUserId/{userId}")]
        public async Task<IActionResult> FindListCommentsByUserId([FromRoute(Name = "userId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(FindListCommentsByUserId)} function in {this.GetType().Name}");
            try
            {
                var user = _userRepository.FindById(Guid.Parse(id));
                if (user == null)
                {
                    _logger.LogError($"Not Load data of {nameof(FindListCommentsByUserId)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Comment with user id {id}" }));
                }
                else
                {
                    var getShareByUserId = _commentService.FindByConditions(e => e.UserId == Guid.Parse(id));
                    _logger.LogInformation($"Loading data of {nameof(FindListCommentsByUserId)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getShareByUserId));
                }
            }
            catch (Exception)
            {
                _logger.LogError($"User ID {id} is not valid! of {nameof(FindListCommentsByUserId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpGet("getListCommentsByBlogId/{blogId}")]
        public async Task<IActionResult> FindListCommentsByBlogId([FromRoute(Name = "blogId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(FindListCommentsByBlogId)} function in {this.GetType().Name}");
            try
            {
                var blog = _blogRepository.FindById(Guid.Parse(id));
                if (blog == null)
                {
                    _logger.LogError($"Not Load data of {nameof(FindListCommentsByBlogId)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Comment with blog id {id}" }));
                }
                else
                {
                    var getListShareByBlogId = _commentService.FindByConditions(e => e.BlogId == Guid.Parse(id));
                    _logger.LogInformation($"Loading data of {nameof(FindListCommentsByBlogId)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getListShareByBlogId));
                }
            }
            catch (Exception)
            {
                _logger.LogError($"User ID {id} is not valid! of {nameof(FindListCommentsByBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpGet("getListCommentsByUserIdAndBlogId")]
        public async Task<IActionResult> FindListCommentsByUserIdAndBlogId([FromQuery(Name = "userId")] string userId, [FromQuery(Name = "blogId")] string blogId)
        {
            _logger.LogInformation($"Begin {nameof(FindListCommentsByUserIdAndBlogId)} function in {this.GetType().Name}");
            UserEntity user;
            BlogEntity blog;
            IEnumerable<CommentEntity> listComment;

            try
            {
                user = _userRepository.FindById(Guid.Parse(userId));
            }
            catch (System.Exception)
            {
                _logger.LogError($"User ID {userId} is not valid! of {nameof(FindListCommentsByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"User ID {userId} is not valid!" }));
            }

            try
            {
                blog = _blogRepository.FindById(Guid.Parse(blogId));
            }
            catch (System.Exception)
            {
                _logger.LogError($"Blog ID {userId} is not valid! of {nameof(FindListCommentsByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Blog ID {userId} is not valid!" }));
            }

            if (user == null)
            {
                _logger.LogError($"Not Load data of {nameof(FindListCommentsByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with user id {userId}" }));
            }
            if (blog == null)
            {
                _logger.LogError($"Not Load data of {nameof(FindListCommentsByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {blogId}" }));
            }

            if (user == null && blog == null)
            {
                _logger.LogError($"Not Load data of {nameof(FindListCommentsByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {blogId} and user id {userId}" }));
            }

            listComment = _commentService.FindByConditions(e => e.UserId == Guid.Parse(userId) && e.BlogId == Guid.Parse(blogId));
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, listComment }));
        }

        [HttpPost("addNewComment")]
        public async Task<IActionResult> AddNewComment([FromBody] CreateCommonDto model)
        {
            _logger.LogInformation($"Begin {nameof(AddNewComment)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(model.UserId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.UserId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewComment)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.UserId)} is not null" }));
            }
            if (string.IsNullOrWhiteSpace(model.BlogId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.BlogId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewComment)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.UserId)} is not null" }));
            }

            var user = _userRepository.FindById(model.UserId);
            if (user == null)
            {
                _logger.LogError($"Not Found {nameof(UserEntity)} by id {model.UserId.ToString()} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found {nameof(UserEntity)} by id {model.UserId.ToString()}" }));
            }

            var blog = _blogRepository.FindById(model.BlogId);
            if (blog == null)
            {
                _logger.LogError($"Not Found {nameof(BlogEntity)} by id {model.BlogId.ToString()} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found {nameof(BlogEntity)} by id {model.BlogId.ToString()}" }));
            }

            var commentId = new Guid();
            CommentEntity entity = _mapper.Map<CommentEntity>(model);
            entity.Id = commentId;
            entity.DateOfCreated = DateTime.UtcNow;
            entity.DateOfModified = DateTime.UtcNow;
            var res = _commentService.Create(entity);
            if (res != null)
            {
                _logger.LogInformation($"Adding data of {nameof(AddNewComment)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, res));
            }
            _logger.LogError($"Not Adding data of {nameof(AddNewComment)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Create {nameof(LikeEntity)} is not successfully" }));
        }

        [HttpPut("updateCommentById/{commentId}")]
        public async Task<IActionResult> UpdateCommentById([FromRoute(Name = "commentId")] string commentId, [FromBody] UpdateCommentDto model)
        {
            _logger.LogInformation($"Begin {nameof(UpdateCommentById)} function in {this.GetType().Name}");
            UserEntity user;
            BlogEntity blog;
            if (string.IsNullOrWhiteSpace(commentId))
            {
                _logger.LogError($"The comment id update in path is not null");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The comment id update in path is not null" }));
            }

            if (string.IsNullOrWhiteSpace(model.Id.ToString()))
            {
                _logger.LogError($"The property {nameof(model.Id)} is null or empty or whitespace in {nameof(model)} of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.Id)} is not null or empty or whitespace." }));
            }

            if (string.IsNullOrWhiteSpace(model.UserId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.UserId)} is null or empty or whitespace in {nameof(model)} of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.UserId)} is not null or empty or whitespace." }));
            }

            if (string.IsNullOrWhiteSpace(model.BlogId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.BlogId)} is null or empty or whitespace in {nameof(model)} of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.BlogId)} is not null or empty or whitespace." }));
            }

            try
            {
                user = _userRepository.FindById(model.UserId);
            }
            catch (System.Exception)
            {
                _logger.LogError($"User ID {model.UserId} is not valid! of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"User ID {model.UserId} is not valid!" }));
            }

            try
            {
                blog = _blogRepository.FindById(model.BlogId);
            }
            catch (System.Exception)
            {
                _logger.LogError($"Blog ID {model.BlogId} is not valid! of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Blog ID {model.BlogId} is not valid!" }));
            }

            if (user == null)
            {
                _logger.LogError($"Not Load data of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with user id {model.UserId}" }));
            }
            if (blog == null)
            {
                _logger.LogError($"Not Load data of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {model.BlogId}" }));
            }

            if (user == null && blog == null)
            {
                _logger.LogError($"Not Load data of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {model.BlogId} and user id {model.UserId}" }));
            }

            try
            {
                var commentIdUUID = Guid.Parse(commentId);
                CommentEntity existedComment = _commentRepository.FindById(commentIdUUID);
                if (!string.Equals(commentId, model.Id.ToString()))
                {
                    _logger.LogError($"The id {commentId} in params is not matched with id {model.Id.ToString()} in the updating model of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"The id {commentId} in params is not matched with id {model.Id.ToString()} in the updating model" }));
                }
                if (existedComment == null)
                {
                    _logger.LogError($"Not Load data of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Comment with id {commentId}" }));
                }
                _mapper.Map(model, existedComment);
                existedComment.DateOfModified = DateTime.UtcNow;
                CommentEntity updatedComment = _commentService.Update(existedComment);
                if (updatedComment != null)
                {
                    _logger.LogInformation($"Updating data of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, updatedComment));
                }
                _logger.LogError($"Not Updating data of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Update comment is not successfully" }));

            }
            catch (Exception)
            {
                _logger.LogError($"ID {commentId} is not valid! of {nameof(UpdateCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {commentId} is not valid!" }));
            }
        }

        [HttpDelete("deleteCommentById/{commentId}")]
        public async Task<IActionResult> DeleteCommentById([FromRoute(Name = "commentId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(DeleteCommentById)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(id))
            {
                _logger.LogError($"Id params of {nameof(DeleteCommentById)} function in {this.GetType().Name} is null.");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Id params is not null or blank or whitespace" }));
            }
            try
            {
                var commentId = Guid.Parse(id);
                CommentEntity exsitedComment = _commentRepository.FindById(Guid.Parse(id));
                if (exsitedComment == null)
                {
                    _logger.LogError($"Not Load data of {nameof(DeleteCommentById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found comment with id {id}" }));
                }
                bool isDeleted = _commentService.Delete(exsitedComment);
                if (isDeleted)
                {
                    _logger.LogInformation($"Deleting data of {nameof(DeleteCommentById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, Message = $"Delete comment is successfully!" }));
                }
                _logger.LogError($"Not Deleting data of {nameof(DeleteCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Delete comment is failed!" }));

            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(DeleteCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogWebApi.Application.Repositories.BlogRepository;
using BlogWebApi.Application.Repositories.CommentEntityRepository;
using BlogWebApi.Application.Repositories.UserEntityRepository;
using BlogWebApi.Application.UnitOfWork;
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
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Share with id {id}" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(GetCommentById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }
    }
}
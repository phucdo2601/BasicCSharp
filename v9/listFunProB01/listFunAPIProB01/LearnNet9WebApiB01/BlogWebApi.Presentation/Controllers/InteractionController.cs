using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogWebApi.Application.Repositories.BlogRepository;
using BlogWebApi.Application.Repositories.InteractionEntityRepository;
using BlogWebApi.Application.Repositories.InteractionTypeEntityRepository;
using BlogWebApi.Application.Repositories.UserEntityRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos.Interactions;
using BlogWebApi.Domain.Services.Blogs;
using BlogWebApi.Domain.Services.Interactions;
using BlogWebApi.Domain.Services.InteractionTypes;
using BlogWebApi.Domain.Services.Users;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogWebApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InteractionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<InteractionController> _logger;
        private readonly IMapper _mapper;
        private readonly IInteractionTypeRepository _interactionTypeRepository;
        private readonly IInteractionRepostiory _interactionRepostiory;
        private readonly IUserRepository _userRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IInteractionService _interactionService;


        public InteractionController(IUnitOfWork unitOfWork, ApplicationDbContext context, ILogger<InteractionController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _interactionTypeRepository = new InteractionTypeRepository(_context);
            _interactionRepostiory = new InteractionRepository(_context);
            _interactionService = new InteractionService(_context, _unitOfWork, _interactionRepostiory);
            _userRepository = new UserRepository(_context);
            _blogRepository = new BlogRepository(_context);
        }

        [HttpGet("getAllInteractions")]
        public async Task<IActionResult> GetAllInteractions()
        {
            _logger.LogInformation($"Begin {nameof(GetAllInteractions)} function in {this.GetType().Name}");
            var listUsers = _interactionService.FindAll();
            if (listUsers.ToList().Count >= 0)
            {
                _logger.LogInformation($"Loading list data of {nameof(GetAllInteractions)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, listUsers));
            }
            _logger.LogError($"Not Load list data of {nameof(GetAllInteractions)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = "Not Found interactions" }));
        }

        [HttpGet("getAllInteractions/{interactionId}")]
        public async Task<IActionResult> GetInteractionById([FromRoute(Name = "interactionId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(GetInteractionById)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(id))
            {
                _logger.LogError($"Id params of {nameof(GetInteractionById)} function in {this.GetType().Name} is null.");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Id params is not null or blank or whitespace" }));
            }
            try
            {
                var getInteractionById = _interactionService.FindById(Guid.Parse(id));
                if (getInteractionById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(GetInteractionById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getInteractionById));
                }
                _logger.LogError($"Not Load data of {nameof(GetInteractionById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Interaction Type with id {id}" }));
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(GetInteractionById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpPost("addNewInteraction")]
        public async Task<IActionResult> AddNewInteraction([FromBody] CreateInteractionDto model)
        {
            _logger.LogInformation($"Begin {nameof(AddNewInteraction)} function in {this.GetType().Name}");
            if (!ModelState.IsValid)
            {
                // Return validation errors
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(model.UserId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.UserId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.UserId)} is not null" }));
            }

            if (string.IsNullOrWhiteSpace(model.BlogId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.BlogId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.BlogId)} is not null" }));
            }

            if (string.IsNullOrWhiteSpace(model.InteractionTypeId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.InteractionTypeId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.InteractionTypeId)} is not null" }));
            }

            UserEntity user;
            BlogEntity blog;
            InteractionTypeEntity interactionType;

            try
            {
                user = _userRepository.FindById(model.UserId);
                if (user == null)
                {
                    _logger.LogError($"Not Found {nameof(UserEntity)} by id {model.UserId.ToString()} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found {nameof(UserEntity)} by id {model.UserId.ToString()}" }));
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"ID {model.UserId} is not valid! of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {model.UserId} is not valid!" }));
            }

            try
            {
                blog = _blogRepository.FindById(model.BlogId);
                if (blog == null)
                {
                    _logger.LogError($"Not Found {nameof(BlogEntity)} by id {model.BlogId.ToString()} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found {nameof(BlogEntity)} by id {model.BlogId.ToString()}" }));
                }
            }
            catch (System.Exception)
            {
                _logger.LogError($"ID {model.BlogId} is not valid! of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {model.BlogId} is not valid!" }));
            }

            try
            {
                interactionType = _interactionTypeRepository.FindById(model.InteractionTypeId);
                if (interactionType == null)
                {
                    _logger.LogError($"Not Found {nameof(InteractionTypeEntity)} by id {model.InteractionTypeId.ToString()} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found {nameof(InteractionTypeEntity)} by id {model.InteractionTypeId.ToString()}" }));
                }
            }
            catch (System.Exception)
            {
                _logger.LogError($"ID {model.InteractionTypeId} is not valid! of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {model.InteractionTypeId} is not valid!" }));
            }

            var interactionId = Guid.NewGuid();
            InteractionEntity entity = _mapper.Map<InteractionEntity>(model);
            entity.Id = interactionId;
            entity.DateOfCreated = DateTime.UtcNow;
            entity.DateOfModified = DateTime.UtcNow;

            InteractionEntity res = _interactionService.Create(entity);
            if (res != null)
            {
                _logger.LogInformation($"Adding data of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, res));
            }
            _logger.LogError($"Not Adding data of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Create {nameof(InteractionEntity)} is not successfully" }));
        }

        [HttpPut("updateInteraction/{interactionId}")]
        public async Task<IActionResult> UpdateInteraction([FromRoute(Name = "interactionId")] string id, [FromBody] UpdateInteractionDto model)
        {
            _logger.LogInformation($"Begin {nameof(AddNewInteraction)} function in {this.GetType().Name}");
            if (!ModelState.IsValid)
            {
                // Return validation errors
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(model.UserId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.UserId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.UserId)} is not null" }));
            }

            if (string.IsNullOrWhiteSpace(model.BlogId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.BlogId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.BlogId)} is not null" }));
            }

            if (string.IsNullOrWhiteSpace(model.InteractionTypeId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.InteractionTypeId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.InteractionTypeId)} is not null" }));
            }

            try
            {
                var interactionId = Guid.Parse(id);
                if (string.Equals(id, model.Id.ToString()))
                {
                    _logger.LogError($"The id {id} in params is not matched with id {model.Id.ToString()} in the updating model of {nameof(UpdateInteraction)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"The id {id} in params is not matched with id {model.Id.ToString()} in the updating model" }));
                }
                InteractionEntity existedInteraction = _interactionRepostiory.FindById(interactionId);
                if (existedInteraction == null)
                {
                    _logger.LogError($"Not Load data of {nameof(existedInteraction)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found interaction with id {id}" }));
                }

                _mapper.Map(model, existedInteraction);
                existedInteraction.DateOfModified = DateTime.UtcNow;
                InteractionEntity updatedInteractionId = _interactionService.Update(existedInteraction);
                if (updatedInteractionId != null)
                {
                    _logger.LogInformation($"Updating data of {nameof(UpdateInteraction)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, updatedInteractionId));
                }
                _logger.LogError($"Not Updating data of {nameof(UpdateInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Update interaction is not successfully" }));

            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(UpdateInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpDelete("deleteInteraction/{interactionId}")]
        public async Task<IActionResult> DeleteInteraction([FromRoute(Name = "interactionId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(DeleteInteraction)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(id))
            {
                _logger.LogError($"Id params of {nameof(DeleteInteraction)} function in {this.GetType().Name} is null.");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Id params is not null or blank or whitespace" }));
            }
            try
            {
                var interactionId = Guid.Parse(id);
                InteractionEntity existedInteraction = _interactionRepostiory.FindById(interactionId);
                if (existedInteraction == null)
                {
                    _logger.LogError($"Not Load data of {nameof(DeleteInteraction)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found interaction with id {id}" }));
                }
                bool isDeleted = _interactionService.Delete(existedInteraction);
                if (isDeleted)
                {
                    _logger.LogInformation($"Deleting data of {nameof(DeleteInteraction)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, Message = $"Delete interaction is successfully!" }));
                }
                _logger.LogError($"Not Deleting data of {nameof(DeleteInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Delete interaction is failed!" }));

            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(DeleteInteraction)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogWebApi.Application.Repositories.InteractionTypeEntityRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos.InteractionTypes;
using BlogWebApi.Domain.Services.InteractionTypes;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InteractionTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly IInteractionTypeRepository _interactionTypeRepository;
        private readonly IInteractionTypeService _interactionTypeService;
        private readonly ILogger<InteractionTypeController> _logger;
        private readonly IMapper _mapper;

        public InteractionTypeController(IUnitOfWork unitOfWork, ApplicationDbContext context, ILogger<InteractionTypeController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _interactionTypeRepository = new InteractionTypeRepository(_context);
            _interactionTypeService = new InteractionTypeService(_context, _unitOfWork, _interactionTypeRepository);
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("getAllInteractionTypes")]
        public async Task<IActionResult> GetAllInteractionTypes()
        {
            _logger.LogInformation($"Begin {nameof(GetAllInteractionTypes)} function in {this.GetType().Name}");
            var listInteractionTypes = _interactionTypeService.FindAll();

            if (listInteractionTypes.ToList().Count >= 0)
            {
                _logger.LogInformation($"Loading list data of {nameof(GetAllInteractionTypes)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, listInteractionTypes }));
            }
            _logger.LogError($"Not Load list data of {nameof(GetAllInteractionTypes)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = "Not Found Interaction Types" }));
        }

        [HttpGet("getInteractionTypeById/{interactionTypeId}")]
        public async Task<IActionResult> GetInteractionTypeById([FromRoute(Name = "interactionTypeId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(GetInteractionTypeById)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(id))
            {
                _logger.LogError($"Id params of {nameof(GetInteractionTypeById)} function in {this.GetType().Name} is null.");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Id params is not null or blank or whitespace" }));
            }
            try
            {
                var getInteractionTypeById = _interactionTypeService.FindById(Guid.Parse(id));
                if (getInteractionTypeById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(GetInteractionTypeById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getInteractionTypeById));
                }
                _logger.LogError($"Not Load data of {nameof(GetInteractionTypeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Interaction Type with id {id}" }));
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(GetInteractionTypeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpPost("addNewInteractionType")]
        public async Task<IActionResult> AddNewInteractionType([FromBody] CreateInteractionTypeDto model)
        {
            _logger.LogInformation($"Begin {nameof(AddNewInteractionType)} function in {this.GetType().Name}");
            if (model.Title == null)
            {
                _logger.LogError($"Interaction type title is required.");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The interaction type title is required." }));
            }
            var interactionTypeId = Guid.NewGuid();
            InteractionTypeEntity entity = _mapper.Map<InteractionTypeEntity>(model);
            entity.Id = interactionTypeId;
            entity.Title = model.Title;
            entity.DateOfCreated = DateTime.UtcNow;
            entity.DateOfModified = DateTime.UtcNow;
            var res = _interactionTypeService.Create(entity);
            if (res != null)
            {
                _logger.LogInformation($"Adding data of {nameof(AddNewInteractionType)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, res));
            }
            _logger.LogError($"Not Adding data of {nameof(AddNewInteractionType)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Create interaction type is not successfully" }));
        }

        [HttpPut("updateInteractionType/{interactionTypeId}")]
        public async Task<IActionResult> UpdateInteractionType([FromRoute(Name = "interactionTypeId")] string id, UpdateInteractionTypeDto model)
        {
            _logger.LogInformation($"Begin {nameof(UpdateInteractionType)} function in {this.GetType().Name}");
            try
            {
                var interactionTypeId = Guid.Parse(id);
                InteractionTypeEntity existedInteractionType = _interactionTypeRepository.FindById(interactionTypeId);
                if (existedInteractionType == null)
                {
                    _logger.LogError($"Not Load data of {nameof(UpdateInteractionType)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found interaction type with id {id}" }));
                }
                _mapper.Map(model, existedInteractionType);
                existedInteractionType.DateOfModified = DateTime.UtcNow;
                InteractionTypeEntity updatedInteractionType = _interactionTypeService.Update(existedInteractionType);
                if (updatedInteractionType != null)
                {
                    _logger.LogInformation($"Updating data of {nameof(UpdateInteractionType)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, updatedInteractionType));
                }
                _logger.LogError($"Not Updating data of {nameof(UpdateInteractionType)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Update interaction type is not successfully" }));

            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(UpdateInteractionType)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpDelete("deleteInteractionType/{interactionTypeId}")]
        public async Task<IActionResult> DeleteInteractionType([FromRoute(Name = "interactionTypeId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(DeleteInteractionType)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(id))
            {
                _logger.LogError($"Id params of {nameof(DeleteInteractionType)} function in {this.GetType().Name} is null.");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Id params is not null or blank or whitespa" }));
            }
            try
            {
                var interactionTypeId = Guid.Parse(id);
                InteractionTypeEntity existedInteractionType = _interactionTypeRepository.FindById(interactionTypeId);
                if (existedInteractionType == null)
                {
                    _logger.LogError($"Not Load data of {nameof(DeleteInteractionType)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found interaction type with id {id}" }));
                }
                bool isDeleted = _interactionTypeService.Delete(existedInteractionType);
                if (isDeleted)
                {
                    _logger.LogInformation($"Deleting data of {nameof(DeleteInteractionType)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, Message = $"Delete interaction type is successfully!" }));
                }
                _logger.LogError($"Not Deleting data of {nameof(DeleteInteractionType)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Delete interaction type is failed!" }));
            }
            catch (System.Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(DeleteInteractionType)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }
    }
}
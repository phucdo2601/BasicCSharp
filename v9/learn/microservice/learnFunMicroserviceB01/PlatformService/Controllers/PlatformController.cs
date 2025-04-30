using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepo _repo;
        public PlatformController(IPlatformRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms....");
            var platforms = _repo.GetAllPlatforms();
            var result = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatformById([FromRoute(Name = "id")] int id)
        {
            Console.WriteLine("Getting Platform by id...");
            var platform = _repo.GetPlatformById(id);
            if (platform != null)
            {
                var result = _mapper.Map<PlatformReadDto>(platform);
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, result));
            }
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new
            {
                message = $"Platform is not found by this id {id}"
            }));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform([FromBody] PlatformCreateDto platformCreateDto)
        {
            Console.WriteLine("Create platform...");
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _repo.CreatePlatform(platformModel);
            _repo.SaveChange();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
            {
                CreatedAtRouteResult = CreatedAtRoute(nameof(GetPlatformById), new
                {
                    Id = platformReadDto.Id
                }, platformReadDto)
            }));


        }


    }
}

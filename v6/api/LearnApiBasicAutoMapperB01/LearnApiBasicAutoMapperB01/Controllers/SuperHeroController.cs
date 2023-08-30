using AutoMapper;
using LearnApiBasicAutoMapperB01.Dtos;
using LearnApiBasicAutoMapperB01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnApiBasicAutoMapperB01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> listHero = new List<SuperHero>{
            new SuperHero {
                Id = 1,
                Name ="Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City",
                DateAdded = new DateTime(2001, 08, 10),
                DateModified = null
            },
            new SuperHero {
                Id = 2,
                Name ="Iron Man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Malibu",
                DateAdded = new DateTime(1970, 05, 29),
                DateModified = null
            }

        };

        private readonly IMapper _mapper;
        public SuperHeroController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("getAllHeroes")]
        public ActionResult<List<SuperHero>> GetAllHeroes()
        {
            
            //return listHero;

            //return value with set auto mapper
            return Ok(listHero.Select(hero => _mapper.Map<SuperHeroDto>(hero)));
        }

        [HttpPost("addNewHero")]
        public ActionResult<List<SuperHero>> AddHero(SuperHeroDto newHero)
        {

           var hero = _mapper.Map<SuperHero>(newHero);

            listHero.Add(hero);
            return Ok(listHero.Select(hero => _mapper.Map<SuperHeroDto>(hero)));

        }
    }
}

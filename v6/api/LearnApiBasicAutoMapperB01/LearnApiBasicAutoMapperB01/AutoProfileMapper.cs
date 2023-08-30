using AutoMapper;
using LearnApiBasicAutoMapperB01.Dtos;
using LearnApiBasicAutoMapperB01.Models;

namespace LearnApiBasicAutoMapperB01
{
    public class AutoProfileMapper : Profile
    {
        //Class config auto mapper
        public AutoProfileMapper()
        {
            //Convert SuperHero to SuperHeroDto
            CreateMap<SuperHero, SuperHeroDto>();

            //Convert SuperHeroDto to SuperHero
            CreateMap<SuperHeroDto, SuperHero>();

        }
    }
}

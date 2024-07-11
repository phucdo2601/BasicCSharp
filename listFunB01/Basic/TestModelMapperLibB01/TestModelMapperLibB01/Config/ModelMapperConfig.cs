using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModelMapperLibB01.Dto;
using TestModelMapperLibB01.Entities;

namespace TestModelMapperLibB01.Config
{
    public class ModelMapperConfig
    {
        public static Mapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                /**
                 * Create Mapping from input model to destination  model
                 * Input model: StudentDto
                 * Destination Model: StudentEntity
                 */
                cfg.CreateMap<StudentDto, StudentEntity>();
            });

            //Create an Instance of Mapper and return that instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}

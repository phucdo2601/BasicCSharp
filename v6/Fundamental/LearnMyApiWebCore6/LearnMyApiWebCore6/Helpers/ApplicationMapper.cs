using AutoMapper;
using LearnMyApiWebCore6.Data;
using LearnMyApiWebCore6.Models;

namespace LearnMyApiWebCore6.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            /**
             * Tao mapper mot chieu: vd: CreateMap<Book, BookModel>(); => mapper tu Book sang BookModel
             * neu muon mapper 2 chieu thi chi can .ReverseMap(); =>  CreateMap<Book, BookModel>().ReverseMap();
             */
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}

using AutoMapper;
using LearnNet8ShoppingWebMVCB01.Data;
using LearnNet8ShoppingWebMVCB01.ViewModels;

namespace LearnNet8ShoppingWebMVCB01.Helpers
{
	public class AutoMapperProfile : Profile
	{
        public AutoMapperProfile()
        {
            /* CreateMap<RegisterVM, KhachHang>()
                 .ForMember(kh => kh.HoTen, option => option.MapFrom(RegisterVM => RegisterVM.HoTen))
                 .ReverseMap();*/


            CreateMap<RegisterVM, KhachHang>();


        }
    }
}

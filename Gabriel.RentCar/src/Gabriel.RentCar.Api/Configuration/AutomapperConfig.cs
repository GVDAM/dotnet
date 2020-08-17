using AutoMapper;
using Gabriel.RentCar.Api.ViewModel;
using Gabriel.RentCar.Business.Model;

namespace Gabriel.RentCar.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Carro, CarroViewModel>().ReverseMap();
            CreateMap<Score, ScoreViewModel>();
            CreateMap<Venda, VendaViewModel>().ReverseMap();
            CreateMap<Vendedor, VendedorViewModel>().ReverseMap();
        }
    }
}

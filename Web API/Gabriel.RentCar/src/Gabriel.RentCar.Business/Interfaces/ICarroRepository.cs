using Gabriel.RentCar.Business.Model;
using System;
using System.Threading.Tasks;

namespace Gabriel.RentCar.Business.Interfaces
{
    public interface ICarroRepository : IRepository<Carro>
    {
        Task<Carro> ObterCarrosVendidosPorVendedor(Guid vendedorId);
        Task<Carro> ObterCarrosNaGaragem();
        Task<Carro> ObterPorAno();

    }
}

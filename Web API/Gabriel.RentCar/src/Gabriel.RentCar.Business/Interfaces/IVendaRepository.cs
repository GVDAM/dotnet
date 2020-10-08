using Gabriel.RentCar.Business.Model;
using System.Threading.Tasks;
using System;

namespace Gabriel.RentCar.Business.Interfaces
{
    public interface IVendaRepository : IRepository<Venda>
    {
        Task<Venda> ObterPorIdCarro(Guid carroId);
    }
}

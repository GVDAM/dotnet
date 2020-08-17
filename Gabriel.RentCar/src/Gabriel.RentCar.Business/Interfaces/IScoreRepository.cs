using Gabriel.RentCar.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel.RentCar.Business.Interfaces
{
    public interface IScoreRepository : IRepository<Score>
    {
        Task<Score> ObterScorePorVendedor(Guid vendedorId);
        //Task<Score> ObterScoreEntreVendedorCliente(Guid vendedorId, Guid clienteId);
    }
}

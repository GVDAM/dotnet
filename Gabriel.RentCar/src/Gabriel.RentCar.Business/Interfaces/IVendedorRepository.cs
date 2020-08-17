using Gabriel.RentCar.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel.RentCar.Business.Interfaces
{
    public interface IVendedorRepository : IRepository<Vendedor>
    {
        //Criar sobrescrita do método ObterTodos() da Repository, para trazer o score junto com o Vendedor
        Task<Vendedor> ObterVendedorScore(Guid vendedorId);
        Task<Vendedor> ObterVendedorScoreVenda(Guid vendedorId, Guid vendaId);
        Task<Vendedor> ObterVendedorComMaiorScore(int scorerId);
        Task<Vendedor> ObterVendedorComMenorScore(int scorerId);
        Task<Vendedor> ObterVendedorComScoreMaiorQue(int scorerId);
        Task<Vendedor> ObterVendedorComScoreMenorQue(int scorerId);
    }
}

using Gabriel.RentCar.Business.Interfaces;
using Gabriel.RentCar.Business.Model;
using Gabriel.RentCar.Data.Context;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gabriel.RentCar.Data.Repository
{
    public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(MyContext context) :base(context) { }


       public async Task<Vendedor> ObterVendedorScore(Guid vendedorId)
       {
           return await Db.Vendedores.AsNoTracking()
               .Include(v => v.Score)
               .FirstOrDefaultAsync(v => v.Id == vendedorId);
       }

        public Task<Vendedor> ObterVendedorScoreVenda(Guid vendedorId, Guid vendaId)
        {
            throw new NotImplementedException();
        }

        public Task<Vendedor> ObterVendedorComMaiorScore(int score)
        {
            throw new NotImplementedException();
        }

        public Task<Vendedor> ObterVendedorComMenorScore(int scorerId)
        {
            throw new NotImplementedException();
        }

        public Task<Vendedor> ObterVendedorComScoreMaiorQue(int scorerId)
        {
            throw new NotImplementedException();
        }

        public Task<Vendedor> ObterVendedorComScoreMenorQue(int scorerId)
        {
            throw new NotImplementedException();
        }
    }
}

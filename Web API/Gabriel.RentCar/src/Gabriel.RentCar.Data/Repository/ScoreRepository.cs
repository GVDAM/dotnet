using Gabriel.RentCar.Business.Interfaces;
using Gabriel.RentCar.Business.Model;
using Gabriel.RentCar.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Gabriel.RentCar.Data.Repository
{
    public class ScoreRepository : Repository<Score>, IScoreRepository
    {
        public ScoreRepository(MyContext context) :base(context) { }

        /*
        public Task<Score> ObterScoreEntreVendedorCliente(Guid vendedorId, Guid clienteId)
        {
            throw new NotImplementedException();
        } 
        */

        public async Task<Score> ObterScorePorVendedor(Guid Id)
        {
            return await Db.Scores.AsNoTracking()                
                .FirstOrDefaultAsync(s => s.VendedorId == Id);

        }
    }
}

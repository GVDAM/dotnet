using Gabriel.RentCar.Business.Model;
using Gabriel.RentCar.Business.Interfaces;
using Gabriel.RentCar.Data.Context;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Gabriel.RentCar.Data.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(MyContext context) :base(context) { }

        public async Task<Venda> ObterPorIdCarro(Guid carroId)
        {
            return await Db.Vendas.AsNoTracking()
                .SingleOrDefaultAsync(s => s.CarroId == carroId);
        }


    }
}

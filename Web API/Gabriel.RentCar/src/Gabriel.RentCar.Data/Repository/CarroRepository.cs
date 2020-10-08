using System;
using System.Threading.Tasks;
using Gabriel.RentCar.Business.Interfaces;
using Gabriel.RentCar.Business.Model;
using Gabriel.RentCar.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gabriel.RentCar.Data.Repository
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {

        public CarroRepository(MyContext context) :base(context) { }

        public Task<Carro> ObterCarrosNaGaragem()
        {
            throw new NotImplementedException();
        }

        public Task<Carro> ObterCarrosVendidosPorVendedor(Guid vendedorId)
        {
            throw new NotImplementedException();
        }

        public Task<Carro> ObterPorAno()
        {
            throw new NotImplementedException();
        }
    }
}

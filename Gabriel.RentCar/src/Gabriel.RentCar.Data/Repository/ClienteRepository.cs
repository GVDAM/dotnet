using Gabriel.RentCar.Business.Model;
using Gabriel.RentCar.Business.Interfaces;
using System.Threading.Tasks;
using System;
using Gabriel.RentCar.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gabriel.RentCar.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MyContext context) : base(context) { }

        
    }
}

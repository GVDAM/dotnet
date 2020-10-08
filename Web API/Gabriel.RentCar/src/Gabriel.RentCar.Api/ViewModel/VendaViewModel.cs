using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel.RentCar.Api.ViewModel
{
    public class VendaViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataVenda { get; set; }
        public int Parcelas { get; set; }
        public Guid VendedorId { get; set; }
        public Guid CarroId { get; set; }
        public Guid ClienteId { get; set; }
    }
}

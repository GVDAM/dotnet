using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel.RentCar.Api.ViewModel
{
    public class ScoreViewModel
    {
        public Guid Id { get; set; }
        public int Pontos { get; set; }
        public Guid VendedorId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Gabriel.RentCar.Business.Model
{
    public class Score : Entity
    {
        public int Pontos { get; set; }
        public Guid VendedorId { get; set; }

    }
}

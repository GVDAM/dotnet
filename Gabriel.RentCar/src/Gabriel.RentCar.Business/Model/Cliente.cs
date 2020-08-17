using System;
using System.Collections.Generic;
using System.Text;

namespace Gabriel.RentCar.Business.Model
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public Venda Venda { get; set; }

    }
}

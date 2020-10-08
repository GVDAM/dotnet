using System;

namespace Gabriel.RentCar.Business.Model
{
    public class Venda : Entity
    {
        public DateTime DataVenda { get; set; }
        public int Parcelas { get; set; }
        public Guid VendedorId { get; set; }
        public Guid CarroId { get; set; }
        public Guid ClienteId { get; set; }

        /* EF Realtion */
        public Vendedor Vendedor { get; set; }
        public Cliente Cliente { get; set; }
        public Carro Carro { get; set; }


    }
}

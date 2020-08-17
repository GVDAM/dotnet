using System.Collections.Generic;

namespace Gabriel.RentCar.Business.Model
{
    public class Vendedor : Entity
    {
        public string Nome { get; set; }
        public int VendasRealizadas { get; set; }
        public Score Score { get; set; }


        /* EF Relation */
        public IEnumerable<Venda> Vendas { get; set; }
    }
}

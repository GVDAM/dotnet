using Gabriel.RentCar.Business.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gabriel.RentCar.Api.ViewModel
{
    public class VendedorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int VendasRealizadas { get; set; }
        //public Score Score { get; set; }
        //public IEnumerable<Venda> Vendas { get; set; }

    }
}

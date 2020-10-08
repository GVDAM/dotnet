using Gabriel.RentCar.Business.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel.RentCar.Api.ViewModel
{
    public class CarroViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public TipoCarro TipoCarro { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }

    }
}

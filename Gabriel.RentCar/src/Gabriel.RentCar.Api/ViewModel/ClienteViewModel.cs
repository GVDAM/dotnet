using System;
using System.ComponentModel.DataAnnotations;

namespace Gabriel.RentCar.Api.ViewModel
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa estar entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campor {0} precisa estar entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} não está no padrão aceitável")]
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multa.Core.Requests.Cliente
{
    public class CreateClienteRequest : Request
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(120, ErrorMessage = "O nome deve conter até 120 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 dígitos numéricos")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "CNH é obrigatória")]
        [MaxLength(20, ErrorMessage = "CNH inválida")]
        public string CNH { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [MaxLength(200, ErrorMessage = "Endereço deve conter até 200 caracteres")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;
    }
}

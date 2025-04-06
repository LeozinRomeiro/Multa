using System.ComponentModel.DataAnnotations;

namespace Multa.Core.Requests.Multa
{
    public class CreateMultaRequest : Request
    {
        [Required(ErrorMessage = "Número do auto de infração é obrigatório")]
        [MaxLength(30, ErrorMessage = "Auto de infração deve conter até 30 caracteres")]
        public string AutoInfracao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Placa do veículo é obrigatória")]
        [RegularExpression(@"^[A-Z]{3}\d[A-Z0-9]\d{2}$", ErrorMessage = "Placa do veículo inválida")]
        public string PlacaVeiculo { get; set; } = string.Empty;

        [Required(ErrorMessage = "RENAVAM é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "RENAVAM deve conter 11 dígitos")]
        public string Renavam { get; set; } = string.Empty;

        [Required(ErrorMessage = "Código da infração é obrigatório")]
        public string CodigoInfracao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição da infração é obrigatória")]
        [MaxLength(255, ErrorMessage = "Descrição da infração deve conter até 255 caracteres")]
        public string DescricaoInfracao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Valor da multa é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor da multa deve ser maior que zero")]
        public decimal ValorMulta { get; set; }

        [Required(ErrorMessage = "Data da infração é obrigatória")]
        public DateTime? DataInfracao { get; set; }

        [Required(ErrorMessage = "Local da infração é obrigatório")]
        [MaxLength(150, ErrorMessage = "Local da infração deve conter até 150 caracteres")]
        public string LocalInfracao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Órgão autuador é obrigatório")]
        public string OrgaoAutuador { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantidade de pontos é obrigatória")]
        [Range(0, 20, ErrorMessage = "Pontos na CNH devem estar entre 0 e 20")]
        public int PontosNaCNH { get; set; }

        [Required(ErrorMessage = "ClienteId é obrigatório")]
        public long ClienteId { get; set; }
    }
}

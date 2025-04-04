namespace Multa.Core.Models
{
    public class Multa
    {
        public long Id { get; set; }
        public string AutoInfracao { get; set; } = string.Empty;
        public string PlacaVeiculo { get; set; } = string.Empty;
        public string Renavam { get; set; } = string.Empty;
        public string CodigoInfracao { get; set; } = string.Empty;
        public string DescricaoInfracao { get; set; } = string.Empty;
        public decimal ValorMulta { get; set; }
        public DateTime DataInfracao { get; set; }
        public string LocalInfracao { get; set; } = string.Empty;
        public string OrgaoAutuador { get; set; } = string.Empty;
        public int PontosNaCNH { get; set; }

        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LogisticERP.Domain
{
    public class Viagem
    {
        [Key]
        public int ViagemID { get; set; }

        [Required]
        [StringLength(200)]
        public string Origem { get; set; } = string.Empty;
        [StringLength(200)]
        public string Destino { get; set; } = string.Empty;

        // Usar DateTime para facilitar consultas, comparações e cálculos
        public DateTime DataSaida { get; set; }
        public DateTime DataChegada { get; set; }
        public TimeSpan HoraSaida { get; set; }
        public TimeSpan HoraChegada { get; set; }


        // Melhor usar enum em vez de string, evita erros de digitação
        public StatusViagem Status { get; set; } = StatusViagem.Pendente;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Chaves estrangeiras para relacionar com Veiculo e Motorista
        [Required]
        public int VeiculoID { get; set; }
        [Required]
        public int MotoristaID { get; set; }

        public required Veiculo Veiculo { get; set; }
        public Motorista? Motorista { get; set; }

        public ICollection<NotaFiscal> NotasFiscais { get; set; } = new Collection<NotaFiscal>();

    }

    // Exemplo de enum pra status da viagem
    public enum StatusViagem
    {
        Pendente,
        EmAndamento,
        Concluida,
        Cancelada
    }
}

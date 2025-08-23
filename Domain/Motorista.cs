using System.ComponentModel.DataAnnotations;

namespace LogisticERP.Domain
{
    public class Motorista
    {
        [Key]
        public int MotoristaID { get; set; }

        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(100)]
        public string Endereco { get; set; } = string.Empty;
        [StringLength(300)]
        public string Observacao { get; set; } = string.Empty;
        [StringLength(300)]
        public string FotoUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Documentos e dados pessoais
        [StringLength(11)]
        public string CPF { get; set; } = string.Empty;
        [StringLength(20)]
        public string CNH { get; set; } = string.Empty;

        // Categoria da CNH não pode ser string aleatória, melhor um enum
        public CategoriaCNH CategoriaCNH { get; set; } = CategoriaCNH.B;

        // Telefone pode ficar como string pra manter DDD, +55 etc
        [StringLength(20)]
        public string Telefone { get; set; } = string.Empty;
    }

    public enum CategoriaCNH
    {
        A,
        B,
        C,
        D,
        E
    }
}

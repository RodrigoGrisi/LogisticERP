using System.ComponentModel.DataAnnotations;

namespace LogisticERP.DTOs
{
    public class MotoristaDTO
    {

        [Key]
        public int MotoristaID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(100)]
        public string Endereco { get; set; } = string.Empty;

        [StringLength(300)]
        public string Observacao { get; set; } = string.Empty;


    }
}

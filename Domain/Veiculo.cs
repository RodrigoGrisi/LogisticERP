using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticERP.Domain;

[Table("Veiculos")]
public class Veiculo
{
    [Key]
    public int VeiculoId { get; set; }
    
    [StringLength(100)] 
    public string Marca { get; set; } = string.Empty;
    [StringLength(100)]
    public string Modelo { get; set; } = string.Empty;
    [StringLength(50)]
    public string Cor { get; set; } = string.Empty;

    [Required]
    public int Ano { get; set; }
    public string ImagemUrl { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;


    // Categoria de veículo pode ser enum (leve, pesado, carreta, etc.)
    public CategoriaVeiculo Categoria { get; set; } = CategoriaVeiculo.Leve;

    public string Observacao { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public double CapacidadeCarga { get; set; }

    // Se o veículo é próprio ou de terceiros
    public PropriedadeVeiculo Propriedade { get; set; } = PropriedadeVeiculo.Proprio;

    // Situação do veículo: ativo, manutenção, inativo, etc.
    public SituacaoVeiculo Situacao { get; set; } = SituacaoVeiculo.Ativo;

    [StringLength(20)]
    public string Placa { get; set; } = string.Empty;
}

public enum CategoriaVeiculo
{
    Leve,
    Medio,
    Pesado,
    Carreta
}

public enum PropriedadeVeiculo
{
    Proprio,
    Terceirizado,
    Agregado
}

public enum SituacaoVeiculo
{
    Ativo,
    EmManutencao,
    Inativo
}

    // Documentos importantes (valores únicos, não podem virar string solta qualquer)
    //public string Renavam { get; set; } = string.Empty;
    //public string Chassi { get; set; } = string.Empty;
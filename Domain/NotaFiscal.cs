namespace LogisticERP.Domain;


public class NotaFiscal
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public DateTime DataEmissao { get; set; }
    public decimal Valor { get; set; }
    public string CnpjEmitente { get; set; }
    public string CnpjDestinatario { get; set; }
    public string Descricao { get; set; }


    // FK para Viagem
    public int ViagemId { get; set; }
    public Viagem Viagem { get; set; }

}


using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticERP.Migrations
{
    /// <inheritdoc />
    public partial class populaVeiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {

            mb.Sql(@"
    INSERT INTO Veiculos 
        (Marca, Modelo, Cor, Ano, ImagemUrl, Categoria, Observacao, CapacidadeCarga, Propriedade, Placa, CreatedAt) 
    VALUES
        ('Volvo', 'EX30', 'Branco', 2020 ,'www.google.com.br', 2 , 'Caminhão Toco', 10000, 3, 'ABC-1234', NOW())
");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {

        }
    }
}

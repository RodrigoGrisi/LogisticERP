using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticERP.Migrations;

/// <inheritdoc />
public partial class popularSomeMotoristas : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder mb)
    {

        mb.Sql(@"
    INSERT INTO Motoristas (Nome, email, Endereco, Observacao, FotoUrl, Cpf, CNH, CategoriaCNH, Telefone) 
    VALUES 
    ('Laurindo Dias Pereira', 'laurindodias@gmail.com', 'Rua Santa Cecilia', 'Não dirige aos sabados', 'www.google.com.br/photoAovivo', '123.456.789-00', 'CNH505050', '3', '(11) 91234-5678'),
    ('Maria Souza', 'maria.souza@gmail.com', 'Av. Brasil', 'Prefere dirigir à noite', 'www.google.com.br/photoMaria', '987.654.321-00', 'CNH1010', 'B', '(11) 92345-6789'),
    ('Carlos Alberto', 'carlos.alberto@gmail.com', 'Rua das Flores', 'Sem restrições', 'www.google.com.br/photoCarlos', '456.789.123-00', 'CNH2020', 'C', '(11) 93456-7890'),
    ('Fernanda Lima', 'fernanda.lima@gmail.com', 'Rua do Sol', 'Não dirige finais de semana', 'www.google.com.br/photoFernanda', '321.654.987-00', 'CNH3030', 'B', '(11) 94567-8901'),
    ('João Pereira', 'joao.pereira@gmail.com', 'Av. Paulista', 'Diretor de frota', 'www.google.com.br/photoJoao', '654.321.987-00', 'CNH4040', 'D', '(11) 95678-9012'),
    ('Ana Martins', 'ana.martins@gmail.com', 'Rua Primavera', 'Treinamento em andamento', 'www.google.com.br/photoAna', '789.123.456-00', 'CNH5050', 'B', '(11) 96789-0123')
");

    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder mb)
    {
    }
}

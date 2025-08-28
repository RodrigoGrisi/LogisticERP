using LogisticERP.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticERP.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Veiculo>? Veiculos { get; set; }
    public DbSet<Motorista>? Motoristas { get; set; }
    public DbSet<Viagem>? Viagens { get; set; }

    public DbSet<NotaFiscal>? NotasFiscais { get; set; }
}


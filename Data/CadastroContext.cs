using Microsoft.EntityFrameworkCore;

public class CadastroContext : DbContext
{
    public CadastroContext(DbContextOptions<CadastroContext> options) : base(options) { }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
}


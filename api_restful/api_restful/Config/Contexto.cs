using api_restful.models;
using Microsoft.EntityFrameworkCore;
namespace api_restful.config;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Servico> TB_SERVICO { get; set; }
    public DbSet<Estabelecimento> TB_ESTABELECIMENTO { get; set; }
    //public DbSet<EstabelecimentoServico> TB_ESTABELECIMENTO_SERVICO { get; set; }

}
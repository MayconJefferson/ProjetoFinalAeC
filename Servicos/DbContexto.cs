using Microsoft.EntityFrameworkCore;
using projetoFinalAeC.Models;

namespace projetoFinalAeC.Servicos
{

public class DbContexto : DbContext
  {
    public DbContexto(DbContextOptions<DbContexto> options) : base (options) { }

    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Profissao> Profissoes { get; set; }
    public DbSet<Emprego> Empregos { get; set; }
  }
}
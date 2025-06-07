using GSProjetoSocial.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GSProjetoSocial.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<FormularioFamilia> FormulariosFamilia { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<PontoApoio> PontosApoio { get; set; }
        public DbSet<PontoColeta> PontosColeta { get; set; }
        public DbSet<Relato> Relatos { get; set; }
    }
}

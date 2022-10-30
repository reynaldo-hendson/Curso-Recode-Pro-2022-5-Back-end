using Agencia.Models;
using Microsoft.EntityFrameworkCore;

namespace Agencia.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Destino> destino { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //HasData verifica se existe dados na tabela, se não existir ele inclui
            modelBuilder.Entity<Destino>().HasData(
                new Destino
                {
                    Id = 1,
                    CidadeNome = "Beijing",
                    Pais = "CHN"
                },
                new Destino
                {
                    Id = 2,
                    CidadeNome = "Mountain View",
                    Pais = "USA"
                }


                );
        }
    }
}

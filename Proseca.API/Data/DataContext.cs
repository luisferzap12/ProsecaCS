using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proseca.Shared.Entidades;

namespace Proseca.API.Data
{
    public class DataContext: IdentityDbContext<User>
    {
        //dbcontext>
        public DataContext(DbContextOptions<DataContext>options):base(options) 
        {
                
        }
        public DbSet<Animal> Animales { get; set; }
        public DbSet<EventoDeSalud> EventosDeSalud { get; set; }
        public DbSet<ProduccionLeche> ProduccionesDeLeche { get; set; }
        public DbSet<Reproduccion> Reproducciones { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Finca> Fincas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

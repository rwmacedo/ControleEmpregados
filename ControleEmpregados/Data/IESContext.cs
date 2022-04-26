using ControleEmpregados.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEmpregados.Data
{
    public class IESContext : DbContext
    {
        public DbSet<Empregado> Empregados { get; set; }

        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Empregado>().ToTable("Empregado");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Empregado;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}
    }
}

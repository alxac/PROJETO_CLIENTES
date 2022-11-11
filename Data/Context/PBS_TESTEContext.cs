using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Data.Mapping;

namespace Data.Models
{
    public partial class PBS_TESTEContext : DbContext
    {
        public PBS_TESTEContext()
        {
        }

        public PBS_TESTEContext(DbContextOptions<PBS_TESTEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClienteEnderecos> ClienteEnderecos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexao = "Data Source=SPBOX\\SQLEXPRESS;Initial Catalog=PBS_TESTE;Integrated Security=True;TrustServerCertificate=True";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conexao);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClienteEnderecos>(new ClienteEnderecosMap().Configure);
            modelBuilder.Entity<Clientes>(new ClientesMap().Configure);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
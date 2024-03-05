using Microsoft.EntityFrameworkCore;
using RICARDOAPI.API.Models;

namespace RICARDOAPI.API.Data
{



    /// Representa o contexto do banco de dados para a aplicação, permitindo operações de banco de dados.
    public class DataContext : DbContext
    {



        /// Define o conjunto de mensagens de contato no banco de dados.
        public DbSet<MensagemContato> MensagensContato { get; set; }




        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações do modelo usando Fluent API
            modelBuilder.Entity<MensagemContato>().HasKey(m => m.Id);
        }
    }
}

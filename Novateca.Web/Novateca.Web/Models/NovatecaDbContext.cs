
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novateca.Web.Models
{
    public class NovatecaDbContext : DbContext { 

        public NovatecaDbContext(DbContextOptions<NovatecaDbContext> options)
        : base(options)
            { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        private void ConfigUser(ModelBuilder constructModel)
        {

            // AJUDA: https://www.devmedia.com.br/entity-framework-core-criando-bases-de-dados-com-migrations/36776
            constructModel.Entity<User>(etd =>
           {
               etd.ToTable("tbUser");
               etd.HasKey(u => u.UserID).HasName("id");
               etd.Property(u => u.UserID).HasColumnName("id").ValueGeneratedOnAdd();
               etd.Property(u => u.FirstName).HasColumnName("firstname").HasMaxLength(20);
               etd.Property(u => u.LastName).HasColumnName("lastname").HasMaxLength(20);
               etd.Property(u => u.Username).HasColumnName("username").HasMaxLength(20);
               etd.Property(u => u.Password).HasColumnName("password").HasMaxLength(255);
           });

           
        }

        protected override void OnModelCreating(ModelBuilder constructModel)
        {
            constructModel.ForSqlServerUseIdentityColumns();
            constructModel.HasDefaultSchema("Novateca.Web");

            ConfigUser(constructModel);
        }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Mapeamento para a tabela User
            //S1: Chave Primária para a tabela User
            modelBuilder.Entity<User>().HasKey(u => u.ClienteId);
            //S2: A chave Identity Key para ClienteId
            modelBuilder.Entity<User>().Property(u => u.ClienteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // tamanho máximo para as propriedades Nome,Endereco,Telefone e Cidade
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasMaxLength(20);
            modelBuilder.Entity<User>().Property(u => u.LastName).HasMaxLength(20);
            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(40);
            modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(255);
            //Mapeamento para a tabela Pedido
            //S1: Chave Primaria para a tabela Pedido
            modelBuilder.Entity<Pedido>().HasKey(p => p.PedidoId);
            //S2: Uma chave identity para o PedidoId
            modelBuilder.Entity<Pedido>().Property(p => p.PedidoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //S2: O tamanho máximo para o item
            modelBuilder.Entity<Pedido>().Property(p => p.Item).HasMaxLength(50);
            //S3: A chave estrangeira para a tabela Pedido - ClienteId
            modelBuilder.Entity<Pedido>().HasRequired(c => c.Cliente)
             .WithMany(p => p.Pedidos).HasForeignKey(p => p.ClienteId);
            // A deleção em cascata a partir de Cliente para Pedidos
            modelBuilder.Entity<Pedido>()
                .HasRequired(c => c.Cliente)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(p => p.ClienteId)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }*/
    }

}

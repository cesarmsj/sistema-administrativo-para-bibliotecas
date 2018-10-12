
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Novateca.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace Novateca.Web.Models
{
    public class NovatecaDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {

        public NovatecaDbContext(DbContextOptions<NovatecaDbContext> options)
        : base(options)
            { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookComment> BookComments { get; set; }
        public DbSet<BookLike> BookLikes { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }

        public DbSet<Multimedia> Multimedia { get; set; }
        public DbSet<MultimediaComment> MultimediaComments { get; set; }
        public DbSet<MultimediaLike> MultimediaLikes { get; set; }
        public DbSet<FavoriteMultimedia> FavoriteMultimedia { get; set; }

        public DbSet<Newspaper> Newspapers { get; set; }
        public DbSet<NewspaperComment> NewspaperComments { get; set; }
        public DbSet<NewspaperLike> NewspaperLikes { get; set; }
        public DbSet<FavoriteNewspaper> FavoriteNewspapers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ForSqlServerUseIdentityColumns();
           // builder.HasDefaultSchema("Novateca.Web");
            builder.ApplyConfiguration(new BookEntityConfiguration());
            builder.ApplyConfiguration(new BookLikeEntityConfiguration());
            builder.ApplyConfiguration(new BookCommentEntityConfiguration());
            builder.ApplyConfiguration(new FavoriteBooksEntityConfiguration());

            builder.ApplyConfiguration(new NewspaperEntityConfiguration());
            builder.ApplyConfiguration(new NewspaperLikeEntityConfiguration());
            builder.ApplyConfiguration(new BookCommentEntityConfiguration());
            builder.ApplyConfiguration(new FavoriteNewspapersEntityConfiguration());

            builder.ApplyConfiguration(new BookEntityConfiguration());
            builder.ApplyConfiguration(new BookLikeEntityConfiguration());
            builder.ApplyConfiguration(new BookCommentEntityConfiguration());
            builder.ApplyConfiguration(new FavoriteBooksEntityConfiguration());

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            
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

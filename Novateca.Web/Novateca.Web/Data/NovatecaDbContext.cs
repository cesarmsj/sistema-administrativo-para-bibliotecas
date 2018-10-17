
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Novateca.Web.Models
{
    public class NovatecaDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {

        public NovatecaDbContext(DbContextOptions<NovatecaDbContext> options)
        : base(options)
            { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Book> Book { get; set; }
        public DbSet<BookComment> BookComments { get; set; }
        public DbSet<BookLike> BookLike { get; set; }
        public DbSet<BookLoan> BookLoan { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }
        public DbSet<BookLikeInComment> BookLikeInComment { get; set; }

        public DbSet<Multimedia> Multimedia { get; set; }
        public DbSet<MultimediaComment> MultimediaComments { get; set; }
        public DbSet<MultimediaLike> MultimediaLikes { get; set; }
        public DbSet<MultimediaLoan> MultimediaLoan { get; set; }
        public DbSet<FavoriteMultimedia> FavoriteMultimedia { get; set; }
        public DbSet<MultimediaLikeInComment> MultimediaLikeInComment { get; set; }

        public DbSet<Newspaper> Newspapers { get; set; }
        public DbSet<NewspaperComment> NewspaperComments { get; set; }
        public DbSet<NewspaperLike> NewspaperLikes { get; set; }
        public DbSet<NewspaperLoan> NewspaperLoan { get; set; }
        public DbSet<FavoriteNewspaper> FavoriteNewspapers { get; set; }
        public DbSet<NewspaperLikeInComment> NewspaperLikeInComment { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ForSqlServerUseIdentityColumns();
          
            // builder.HasDefaultSchema("Novateca.Web");
            builder.ApplyConfiguration(new BookEntityConfiguration());
            builder.ApplyConfiguration(new BookLikeEntityConfiguration());
            builder.ApplyConfiguration(new BookLikeInCommentEntityConfiguration());
            builder.ApplyConfiguration(new BookCommentEntityConfiguration());
            builder.ApplyConfiguration(new FavoriteBooksEntityConfiguration());

            builder.ApplyConfiguration(new MultimediaEntityConfiguration());
            builder.ApplyConfiguration(new MultimediaLikeEntityConfiguration());
            builder.ApplyConfiguration(new MultimediaLikeInCommentEntityConfiguration());
            builder.ApplyConfiguration(new MultimediaCommentEntityConfiguration());
            builder.ApplyConfiguration(new FavoriteMultimediasEntityConfiguration());

            builder.ApplyConfiguration(new NewspaperEntityConfiguration());
            builder.ApplyConfiguration(new NewspaperLikeEntityConfiguration());
            builder.ApplyConfiguration(new NewspaperLikeInCommentEntityConfiguration());
            builder.ApplyConfiguration(new NewspaperCommentEntityConfiguration());
            builder.ApplyConfiguration(new FavoriteNewspapersEntityConfiguration());

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            
        }

    }


}

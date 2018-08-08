using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Novateca.Web.Models
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.UserID).HasName("UserID");
            builder.Property(c => c.UserID).HasColumnName("UserID").ValueGeneratedOnAdd();
            builder.Property(c => c.FirstName).HasColumnName("Firstname").HasMaxLength(20).IsRequired();
            builder.Property(c => c.LastName).HasColumnName("Lastname").HasMaxLength(20).IsRequired();
            builder.Property(c => c.Username).HasColumnName("Username").HasMaxLength(20).IsRequired();
            builder.Property(c => c.Password).HasColumnName("Password").HasMaxLength(255).IsRequired();
       
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Novateca.Web.Models
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(c => c.UserID).HasName("UserID");
            builder.Property(c => c.UserID).HasColumnName("UserID").ValueGeneratedOnAdd();
            builder.Property(c => c.Username).HasColumnName("Username").HasMaxLength(20).IsRequired();
            builder.Property(c => c.FirstName).HasColumnName("Firstname").HasMaxLength(20).IsRequired();
            builder.Property(c => c.LastName).HasColumnName("Lastname").HasMaxLength(20).IsRequired();
            builder.Property(c => c.User_CPF).HasColumnName("User_CPF").HasMaxLength(11);
            builder.Property(c => c.Password).HasColumnName("Password").HasMaxLength(255).IsRequired();
            builder.Property(c => c.ConfirmPassword).HasColumnName("ConfirmPassword").HasMaxLength(255).IsRequired();
        }
    }
}

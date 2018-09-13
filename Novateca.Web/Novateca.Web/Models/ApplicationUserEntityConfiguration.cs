using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Novateca.Web.Models
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");
            builder.Property(c => c.FirstName).HasColumnName("Firstname").HasMaxLength(20).IsRequired();
            builder.Property(c => c.LastName).HasColumnName("Lastname").HasMaxLength(20).IsRequired();
            builder.Property(c => c.User_CPF).HasColumnName("User_CPF").HasMaxLength(11);
        }
    }
}

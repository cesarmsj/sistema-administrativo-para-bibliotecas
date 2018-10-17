using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class NewspaperLoanEntityConfiguration : IEntityTypeConfiguration<NewspaperLoan>
    {
        public void Configure(EntityTypeBuilder<NewspaperLoan> builder)
        {

            builder.ToTable("NewspaperLoan");
            builder.HasKey(c => c.NewspaperLoanID);
            builder.Property(c => c.NewspaperLoanID).HasColumnName("NewspaperLoanID").ValueGeneratedOnAdd();
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.NewspaperLoans).HasForeignKey(c => c.UserID);
            builder.HasOne(c => c.Newspaper).WithMany(u => u.NewspaperLoans).HasForeignKey(c => c.NewspaperID);
        }

    }
}
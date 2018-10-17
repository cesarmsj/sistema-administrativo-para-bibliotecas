using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class MultimediaLoanEntityConfiguration : IEntityTypeConfiguration<MultimediaLoan>
    {
        public void Configure(EntityTypeBuilder<MultimediaLoan> builder)
        {

            builder.ToTable("MultimediaLoan");
            builder.HasKey(c => c.MultimediaLoanID);
            builder.Property(c => c.MultimediaLoanID).HasColumnName("MultimediaLoanID").ValueGeneratedOnAdd();
            builder.HasOne(c => c.ApplicationUser).WithMany(u => u.MultimediaLoans).HasForeignKey(c => c.UserID);
            builder.HasOne(c => c.Multimedia).WithMany(u => u.MultimediaLoans).HasForeignKey(c => c.MultimediaID);
        }

    }
}
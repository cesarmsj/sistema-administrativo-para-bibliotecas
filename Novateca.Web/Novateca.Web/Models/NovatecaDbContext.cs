using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Novateca.Web.Models
{
    public class NovatecaDbContext : DbContext { 

            public NovatecaDbContext(DbContextOptions<NovatecaDbContext> options)
        : base(options)
            { }

    public DbSet<User> Users { get; set; }
    public DbSet<Information> Informations { get; set; }
    }

}

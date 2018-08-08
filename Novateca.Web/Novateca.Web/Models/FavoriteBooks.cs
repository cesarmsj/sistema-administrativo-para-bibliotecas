using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class FavoriteBooks
    {
        [Key]
        public int FavoriteID { get; set; }

        public User user;

        public int? IdBook { get; set; }
        public Book book;
    }
}

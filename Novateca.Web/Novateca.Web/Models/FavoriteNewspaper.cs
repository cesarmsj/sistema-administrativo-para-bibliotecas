using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class FavoriteNewspaper
    {
        public int FavoriteNewspaperID { get; set; }

        public int UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int NewspaperID { get; set; }
        public virtual Newspaper Newspaper { get; set; }
    }
}

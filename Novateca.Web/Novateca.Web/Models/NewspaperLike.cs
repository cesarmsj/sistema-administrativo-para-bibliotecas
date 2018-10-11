using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class NewspaperLike
    {
        public int NewspaperLikeID { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int NewspaperID { get; set; }
        public virtual Newspaper Newspaper { get; set; }
    }
}

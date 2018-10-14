using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class BookLike
    {
        public int BookLikeID { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int BookID { get; set; }
        public virtual Book Book { get; set; }

        public DateTime LikeDate { get; set; }
        public bool LikeEnabled { get; set; }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class BookComment
    {
        public int BookCommentID { get; set; }

        public int UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int BookID { get; set; }
        public virtual Book Book { get; set; }

        public string Comment { get; set; }
    }
}

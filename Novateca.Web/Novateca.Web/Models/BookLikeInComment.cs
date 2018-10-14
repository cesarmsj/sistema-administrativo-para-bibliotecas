using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class BookLikeInComment
    {
        public int BookLikeInCommentID { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int BookCommentID { get; set; }
        public virtual BookComment BookComment { get; set; }
    }
}

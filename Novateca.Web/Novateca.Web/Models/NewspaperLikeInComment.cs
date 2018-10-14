using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class NewspaperLikeInComment
    {
        public int NewspaperLikeInCommentID { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int NewspaperCommentID { get; set; }
        public virtual NewspaperComment NewspaperComment { get; set; }

        public DateTime LikeDate { get; set; }
        public bool LikeEnabled { get; set; }
    }
}

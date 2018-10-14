using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class NewspaperComment
    {
        public int NewspaperCommentID { get; set; }

        public int UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int NewspaperID { get; set; }
        public virtual Newspaper Newspaper { get; set; }

        public string Comment { get; set; }

        public DateTime CommentDate { get; set; }

        public bool CommentEnabled { get; set; }

        public virtual ICollection<NewspaperLikeInComment> NewspaperLikeInComments { get; set; }
    }
}

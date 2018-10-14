using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class MultimediaLikeInComment
    {
        public int MultimediaLikeInCommentID { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int MultimediaCommentID { get; set; }
        public virtual MultimediaComment MultimediaComment { get; set; }

        public DateTime LikeDate { get; set; }
        public bool LikeEnabled { get; set; }
    }
}

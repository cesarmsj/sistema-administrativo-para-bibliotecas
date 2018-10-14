using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class MultimediaComment
    {
        public int MultimediaCommentID { get; set; }

        public int UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int MultimediaID { get; set; }
        public virtual Multimedia Multimedia { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<MultimediaLikeInComment> MultimediaLikeInComments { get; set; }
    }
}

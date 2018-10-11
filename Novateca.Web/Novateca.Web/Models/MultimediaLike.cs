using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class MultimediaLike
    {
        public int MultimediaLikeID { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int MultimediaID { get; set; }
        public virtual Multimedia Multimedia { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class FavoriteMultimedia
    {
        public int FavoriteMultimediaID { get; set; }

        public int UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int MultimediaID { get; set; }
        public virtual Multimedia Multimedia { get; set; }
    }
}

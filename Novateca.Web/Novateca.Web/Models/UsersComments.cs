using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class UsersComments
    {

        public string Comment { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string PhotoUser { get; set; }

        public DateTime CommentDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class UserMultimediaLoans
    {
        public int MultimediaLoanID { get; set; }

        public int UserID { get; set; }

        public int MultimediaID { get; set; }

        public string MultimediaTitle { get; set; }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string PhotoUser { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime DevolutionDate { get; set; }

        public DateTime DevolutionDateMade { get; set; }
    }
}

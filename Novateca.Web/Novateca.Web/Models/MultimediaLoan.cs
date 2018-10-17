using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class MultimediaLoan
    {
        public int MultimediaLoanID { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime DevolutionDate { get; set; }

        public DateTime DevolutionDateMade { get; set; }

        public int UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int MultimediaID { get; set; }
        public virtual Multimedia Multimedia { get; set; }
    }
}

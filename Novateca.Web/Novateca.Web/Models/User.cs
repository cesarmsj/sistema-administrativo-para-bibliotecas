using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class User
    {
        
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        public string Email { get; set; }

        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Por favor, confirme seu password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public virtual ICollection<BookLike> BookLikes { get; set; }
        public virtual ICollection<FavoriteBook> FavoriteBooks { get; set; }
    }
}

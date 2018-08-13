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

        public string Username { get; set; }

        // admin or user
        public string Profile { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        //Ver este site sobre consulta de CPF na receita: https://github.com/ACBrNet/ACBr.Net.Consulta/blob/master/src/ACBr.Net.Consulta/Receita/ACBrConsultaCPF.cs
        //CPF aparece como 'nome de coluna inválido' no SQL Server
        public string User_CPF { get; set; }

     //   [DataType(DataType.Password)]
     //   [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
        public string Password { get; set; }

     //   [DataType(DataType.Password)]
     //   [Compare(nameof(Password), ErrorMessage ="As senhas não coincidem")]
        public string ConfirmPassword { get; set; }

        public virtual ICollection<BookLike> BookLikes { get; set; }
        public virtual ICollection<BookComment> BookComments { get; set; }
        public virtual ICollection<FavoriteBook> FavoriteBooks { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        /* Do IdentityUser

            public IdentityUser();
            public IdentityUser(string userName);

            public virtual DateTimeOffset? LockoutEnd { get; set; }
            public virtual bool TwoFactorEnabled { get; set; }
            public virtual bool PhoneNumberConfirmed { get; set; }
            public virtual string PhoneNumber { get; set; }
            public virtual string ConcurrencyStamp { get; set; }
            public virtual string SecurityStamp { get; set; }
            public virtual string PasswordHash { get; set; }
            public virtual bool EmailConfirmed { get; set; }
            public virtual string NormalizedEmail { get; set; }
            public virtual string Email { get; set; }
            public virtual string NormalizedUserName { get; set; }
            public virtual string UserName { get; set; }
            public virtual TKey Id { get; set; }
            public virtual bool LockoutEnabled { get; set; }
            public virtual int AccessFailedCount { get; set; }

        */

        // admin or user
        //public string Profile { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //Ver este site sobre consulta de CPF na receita: https://github.com/ACBrNet/ACBr.Net.Consulta/blob/master/src/ACBr.Net.Consulta/Receita/ACBrConsultaCPF.cs
        //CPF aparece como 'nome de coluna inválido' no SQL Server
        public string User_CPF { get; set; }

        public string URLProfilePicture { get; set; }

        // Endereço eu faço outra tabela com chave estrangeira do usuário


        public virtual ICollection<BookLike> BookLikes { get; set; }
        public virtual ICollection<BookLikeInComment> BookLikeInComments { get; set; }
        public virtual ICollection<BookComment> BookComments { get; set; }
        public virtual ICollection<BookLoan> BookLoans { get; set; }
        public virtual ICollection<FavoriteBook> FavoriteBooks { get; set; }
        public virtual ICollection<MultimediaLike> MultimediaLikes { get; set; }
        public virtual ICollection<MultimediaLikeInComment> MultimediaLikeInComments { get; set; }
        public virtual ICollection<MultimediaLoan> MultimediaLoans { get; set; }
        public virtual ICollection<MultimediaComment> MultimediaComments { get; set; }
        public virtual ICollection<FavoriteMultimedia> FavoriteMultimedias { get; set; }
        public virtual ICollection<NewspaperLike> NewspaperLikes { get; set; }
        public virtual ICollection<NewspaperLikeInComment> NewspaperLikeInComments { get; set; }
        public virtual ICollection<NewspaperLoan> NewspaperLoans { get; set; }
        public virtual ICollection<NewspaperComment> NewspaperComments { get; set; }
        public virtual ICollection<FavoriteNewspaper> FavoriteNewspapers { get; set; }


    }
}

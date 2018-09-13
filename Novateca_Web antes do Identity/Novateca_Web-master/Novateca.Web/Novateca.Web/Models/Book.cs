using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class Book
    {
        public int BookID { get; set; }
        // Campo a do 245 do MARC
        public string TitleMain { get; set; }
        // subcampo b do 245
        public string SubTitle { get; set; }
        // CAMPO 100 DO MARC Pessoa Física, se Entidade é 110
        public string AuthorMain { get; set; }
        // subcampo c do 245
        public string Authors { get; set; }
        // CAMPO 250 DO MARC subcampo a
        public string Edition { get; set; }
        // Campo 260 Local da Publicação
        // subcampo a é o local, b é a editora, c é a data
        public string Locate { get; set; }
        public string PublishingCompany { get; set; }
        public int Year { get; set; }
        // Campo 300 subcampo a, total de paginas
        public int TotalPages { get; set; }
        // Campo 697 é o assunto
        public string Subject { get; set; }
        // Campo 856 do MARC
        public string URLImage { get; set; }
        // 
        public string URLEbook { get; set; }

        public virtual ICollection<BookLike> BookLikes { get; set; }
        public virtual ICollection<BookComment> BookComments { get; set; }
        public virtual ICollection<FavoriteBook> FavoriteBooks { get; set; }

    }
}

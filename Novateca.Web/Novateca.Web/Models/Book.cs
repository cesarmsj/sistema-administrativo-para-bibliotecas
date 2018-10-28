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
        [Required(ErrorMessage = "Por favor, informe o Título do Livro")]
        public string TitleMain { get; set; }
        // subcampo b do 245
        public string SubTitle { get; set; }
        // CAMPO 100 DO MARC Pessoa Física, se Entidade é 110
        [Required(ErrorMessage = "Por favor, informe o Autor Principal")]
        public string AuthorMain { get; set; }
        // subcampo c do 245
        [Required(ErrorMessage = "Por favor, informe um ou mais autores")]
        public string Authors { get; set; }
        // CAMPO 250 DO MARC subcampo a
        [Required(ErrorMessage = "Por favor, informe a edição")]
        public string Edition { get; set; }
        // Campo 260 Local da Publicação
        // subcampo a é o local, b é a editora, c é a data
        [Required(ErrorMessage = "Por favor, informe o local de publicação")]
        public string PlaceOfPublication { get; set; }
        [Required(ErrorMessage = "Por favor, informe a editora")]
        public string PublishingCompany { get; set; }
        [Required(ErrorMessage = "Por favor, informe o ano de publicação")]
        public int YearOfPublication { get; set; }
        // Campo 300 subcampo a, total de paginas
        [Required(ErrorMessage = "Por favor, informe o total de páginas")]
        public int TotalPages { get; set; }
        // Campo 697 é o assunto
        [Required(ErrorMessage = "Por favor, informe o gênero do livro")]
        public string BookSubject { get; set; }

        public string Abstract { get; set; }

        [Required(ErrorMessage ="Por favor, informe o ISBN")]
        public string ISBN { get; set; }
        // Campo 856 do MARC
        public string URLImage { get; set; }
        // 
        public string URLEbook { get; set; }

        public virtual ICollection<BookLike> BookLikes { get; set; }
        public virtual ICollection<BookLoan> BookLoans { get; set; }
        public virtual ICollection<BookComment> BookComments { get; set; }
        public virtual ICollection<FavoriteBook> FavoriteBooks { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class Newspaper
    {
        // Exemplares de Revistas (Edições)

        public int NewspaperID { get; set; }
        // Campo a do 773t do MARC (título da revista)
        [Required(ErrorMessage = "Por favor, informe o título do livro")]
        public string TitleMain { get; set; }
        // subcampo b do 245
        public string SubTitle { get; set; }
        // CAMPO 250 DO MARC subcampo a
        [Required(ErrorMessage = "Por favor, informe a Edição")]
        public string Edition { get; set; }
        // Campo 260 Local da Publicação
        // subcampo a é o local, b é a editora, c é a data
        [Required(ErrorMessage = "Por favor, informe o local de publicação")]
        public string PlaceOfPublication { get; set; }
        [Required(ErrorMessage = "Por favor, informe a editora")]
        public string PublishingCompany { get; set; }
        // Campo 697 é o assunto
        [Required(ErrorMessage = "Por favor, informe o gênero")]
        public string NewspaperSubject { get; set; }
        // Campo 310a Periodicidade Atual (anual, semanal, mensal)
        [Required(ErrorMessage = "Por favor, informe a periodicidade")]
        public string CurrentPeriodicity { get; set; }
        [Required(ErrorMessage = "Por favor, informe o ISSN")]
        public string ISSN { get; set; }
        // Campo 856 do MARC
        public string URLImage { get; set; }

        public byte[] AvatarImage { get; set; }

        public virtual ICollection<NewspaperLike> NewspaperLikes { get; set; }
        public virtual ICollection<NewspaperLoan> NewspaperLoans { get; set; }
        public virtual ICollection<NewspaperComment> NewspaperComments { get; set; }
        public virtual ICollection<FavoriteNewspaper> FavoriteNewspaper { get; set; }
    }
}

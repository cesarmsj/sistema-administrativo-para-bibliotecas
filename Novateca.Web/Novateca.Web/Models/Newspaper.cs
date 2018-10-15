using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class Newspaper
    {
        // Exemplares de Revistas (Edições)

        public int NewspaperID { get; set; }
        // Campo a do 773t do MARC (título da revista)
        public string TitleMain { get; set; }
        // subcampo b do 245
        public string SubTitle { get; set; }
        // CAMPO 250 DO MARC subcampo a
        public string Edition { get; set; }
        // Campo 260 Local da Publicação
        // subcampo a é o local, b é a editora, c é a data
        public string Locate { get; set; }
        public string PublishingCompany { get; set; }
        // Campo 697 é o assunto
        public string Subject { get; set; }
        // Campo 310a Periodicidade Atual (anual, semanal, mensal)
        public string CurrentPeriodicity { get; set; }

        public string ISSN { get; set; }
        // Campo 856 do MARC
        public string URLImage { get; set; }
       

        public virtual ICollection<NewspaperLike> NewspaperLikes { get; set; }
        public virtual ICollection<NewspaperComment> NewspaperComments { get; set; }
        public virtual ICollection<FavoriteNewspaper> FavoriteNewspaper { get; set; }
    }
}

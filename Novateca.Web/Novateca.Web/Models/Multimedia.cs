using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class Multimedia
    {
        public int MultimediaID { get; set; }
        // Campo a do 245 do MARC
        public string TitleMain { get; set; }
        // Campo 245h DGM (formato [gravação de vídeo])
        public string DGM { get; set; }
        // subcampo b do 245
        public string SubTitle { get; set; }
        // CAMPO 245c DO MARC Diretores
        public string Director { get; set; }
        // Campo 260 Local da Publicação
        // subcampo a é o local, b é a editora, c é a data
        public string PlaceOfPublication { get; set; }
        public string PublishingCompany { get; set; }
        public int YearOfPublication { get; set; }
        // Campo 300 Descrição Física (Exemplo: 1 DVD(148min))
        public string PhysicalDescription { get; set;  }
        // Campo 697 é o assunto (suspense, drama, terror)
        public string MultimediaSubject { get; set; }
        // Campo 520a é o Resumo
        public string Abstract { get; set; }
        // Campo 511 é o Nota de Participantes
        public string NoteOfParticipants { get; set; }
        // Campo 521a é o Nota público alvo (livre ou não recomendado para menores de .... )
        public string TargetAudience { get; set; }
        // Campo 546a é o Nota Idioma
        public string Language { get; set; }
        // Campo 856 do MARC
        public string URLImage { get; set; }
       

        public virtual ICollection<MultimediaLike> MultimediaLikes { get; set; }
        public virtual ICollection<MultimediaComment> MultimediaComments { get; set; }
        public virtual ICollection<MultimediaLoan> MultimediaLoans { get; set; }
        public virtual ICollection<FavoriteMultimedia> FavoriteMultimedias { get; set; }
    }
}

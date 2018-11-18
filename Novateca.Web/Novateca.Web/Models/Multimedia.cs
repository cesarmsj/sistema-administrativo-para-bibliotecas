using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Models
{
    public class Multimedia
    {
        public int MultimediaID { get; set; }
        // Campo a do 245 do MARC
        [Required(ErrorMessage = "Por favor, informe o Título da Multimídia")]
        public string TitleMain { get; set; }
        // Campo 245h DGM (formato [gravação de vídeo])
        [Required(ErrorMessage = "Por favor, informe o DGM")]
        public string DGM { get; set; }
        // subcampo b do 245
        public string SubTitle { get; set; }
        // CAMPO 245c DO MARC Diretores
        [Required(ErrorMessage = "Por favor, informe o diretor")]
        public string Director { get; set; }
        // Campo 260 Local da Publicação
        // subcampo a é o local, b é a editora, c é a data
        [Required(ErrorMessage = "Por favor, informe o local de lançamento")]
        public string PlaceOfPublication { get; set; }
        [Required(ErrorMessage = "Por favor, informe a companhia cinematográfica")]
        public string PublishingCompany { get; set; }
        [Required(ErrorMessage = "Por favor, informe o ano de lançamento")]
        public int YearOfPublication { get; set; }
        // Campo 300 Descrição Física (Exemplo: 1 DVD(148min))
        [Required(ErrorMessage = "Por favor, informe a descrição física")]
        public string PhysicalDescription { get; set;  }
        // Campo 697 é o assunto (suspense, drama, terror)
        [Required(ErrorMessage = "Por favor, informe o gênero")]
        [MaxLength(20, ErrorMessage = "Por favor, informe até 20 caracteres no máximo")]
        public string MultimediaSubject { get; set; }
        // Campo 520a é o Resumo
        public string Abstract { get; set; }
        // Campo 511 é o Nota de Participantes
        [Required(ErrorMessage = "Por favor, informe um ou mais participantes")]
        public string NoteOfParticipants { get; set; }
        // Campo 521a é o Nota público alvo (livre ou não recomendado para menores de .... )
        [Required(ErrorMessage = "Por favor, informe o público alvo")]
        public string TargetAudience { get; set; }
        // Campo 546a é o Nota Idioma
        [Required(ErrorMessage = "Campo idioma é obrigatório")]
        public string Language { get; set; }
        // Campo 856 do MARC
        public string URLImage { get; set; }

        public byte[] AvatarImage { get; set; }


        public virtual ICollection<MultimediaLike> MultimediaLikes { get; set; }
        public virtual ICollection<MultimediaComment> MultimediaComments { get; set; }
        public virtual ICollection<MultimediaLoan> MultimediaLoans { get; set; }
        public virtual ICollection<FavoriteMultimedia> FavoriteMultimedias { get; set; }
    }
}

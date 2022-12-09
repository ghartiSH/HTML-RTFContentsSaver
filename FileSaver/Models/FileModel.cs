using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileSaver.Models
{
    public class FileModel
    {
        [Key]
        public int ID { get; set; }

        [Column("Superclass(es)")]
        public string? Superclass { get; set; }
        public string? Label { get; set; }
        public string? IRI { get; set; }
        public string? Type { get; set; }
        public string? Sali_appealsTo { get; set; }
        public string? Sali_hasExpense { get; set; }
        public string? Sali_filed { get; set; }
        public string? Sali_seeksToAchieve { get; set; }
        public string? Sali_workedFor { get; set; }
        public string? Sali_cited { get; set; }
        public string? Sali_participatedIn { get; set; }
        public string? LocatedIn { get; set; }
        public string? SeeAlso { get; set; }
        public string? IsAuthor { get; set; }
        public string? SameAs { get; set; }
        public string? Before { get; set; }
        public string? Sali_seealso { get; set; }
        public string? legacyIdentifier { get; set; }
        public string? Description { get; set; }
        public string? Identifier { get; set; }

        [Column("http://webprotege.stanford.edu/RBwBJ2lKdRgVYPkQmoJN1pD")]
        public string? LinkFirst { get; set; }

        [Column("http://webprotege.stanford.edu/RCAWR19VGcj184M2SBAaeoj")]
        public string? LinkSecond { get; set; }
        public string? HasRelatedSynonym { get; set; }
        public string? Comment { get; set; }
        public string? IsDefinedBy { get; set; }
        public string? Deprecated { get; set; }
        public string? InverseOf { get; set; }
        public string? AltLabel { get; set; }
        public string? Definition { get; set; }
        public string? HiddenLabel { get; set; }
        public string? PrefLabel { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FileSaver.Models
{
    public class Filess
    {
        [Key]
        public int FileId { get; set; }
        public string? FileContent { get; set; }
    }
}

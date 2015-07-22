using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitAbridged.Models
{
    public class Snippet
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
        public List<string> SnippetList { get; set; }
    }
}
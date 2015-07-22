using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BitAbridged.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        public string Use { get; set; }
        public bool Imperative { get; set; }
        public bool ObjectOriented { get; set; }
        public bool Functional { get; set; }
        public bool Procedural { get; set; }
        public bool Generic { get; set; }
        public bool Reflective { get; set; }
        public bool EventDriven { get; set; }
        public string Standardized { get; set; }
        public List<Snippet> Snippets { get; set; }
    }
}
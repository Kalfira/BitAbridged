using System.ComponentModel.DataAnnotations;

namespace BitAbridged.Models
{
    public class Searchable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
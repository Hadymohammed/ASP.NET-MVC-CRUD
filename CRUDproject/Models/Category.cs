using System.ComponentModel.DataAnnotations;

namespace CRUDproject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Displayname { get; set; }
        public DateTime createdDate { get; } = DateTime.Now;
    }
}

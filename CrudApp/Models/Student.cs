using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(1000)]
        public string Name { get; set; }
        [Required]
        public string Roll { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}

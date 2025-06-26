using API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tasks")]
    public class TaskItem
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string title { get; set; }
        public string description { get; set; }

        [Required]
        public Priority priority { get; set; }

        [Required]
        public Status status { get; set; }

        [Required]
        public DateTime datecreation { get; private set; } = DateTime.UtcNow;

    }
}

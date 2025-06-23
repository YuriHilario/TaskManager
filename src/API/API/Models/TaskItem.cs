using API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Tasks")]
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public DateTime DateCreation { get; private set; } = DateTime.UtcNow;

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs.Auth
{
    public class LoginRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("PasswordHash")]
        public string Password { get; set; }
    }
}

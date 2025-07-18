﻿using API.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Tasks
{
    public class UpdateTaskDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}

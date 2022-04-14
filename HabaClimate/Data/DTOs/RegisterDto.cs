using System;
using System.ComponentModel.DataAnnotations;

namespace HabaClimate.DTOs
{
    public class RegisterDto
    {
        [Required] public string Username { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
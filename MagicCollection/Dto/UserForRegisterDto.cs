using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicCollection.API.Dto
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "You must specify password between 6 and 16 characters.")]
        public string Password { get; set; }
    }
}

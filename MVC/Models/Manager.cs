using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace networkProj.Models
{
    public class Manager
    {
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "user name length sould be between 4 and 8 characters")]
        public string managName { get; set; }

        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "password should contain 4 digits")]
        public String password { get; set; }
    }
}
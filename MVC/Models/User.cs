using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace networkProj.Models
{
    public class User
    {
        
        [Required]
        [StringLength(8, MinimumLength=4, ErrorMessage="user name length sould be between 4 and 8 characters")]
        public string usrName { get; set; }

        [Key]
        public int uid { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Minimum Length of Password is 4")]
        public String password { get; set; }
    }
}
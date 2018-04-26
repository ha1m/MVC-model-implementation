using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace networkProj.Models
{
    public class Product
    {
        [Key]
        public int pid { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "manufacturer length sould be maximum 10 characters")]
        public string manufacturer { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "model length sould be maximum 10 characters")]
        public string model { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "category length sould be maximum 10 characters")]
        public string category { get; set; }


        [Required]
        public int price { get; set; }

        [Required]
        public int discount { get; set; }
    }
}
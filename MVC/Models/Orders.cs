using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace networkProj.Models
{
    public class Orders
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pid { get; set; }

        public int uid { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using networkProj.Models;

namespace networkProj.ViewModel
{
    public class VM
    {
        public User user { get; set; }

        public List<User> users { get; set; }

        public Product product { get; set; }

        public List<Product> products { get; set; }

        public Orders order { get; set; }

        public List<Orders> orders { get; set; }
    }
}
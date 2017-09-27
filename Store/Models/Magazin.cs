using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Magazin
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int dayofweek { get; set; }

        public DateTime workfrom { get; set; }

        public DateTime workto { get; set; }

        public DateTime intervalfrom { get; set; }

        public DateTime intervalto { get; set; }
    }
}
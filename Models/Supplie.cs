using System;
using System.Collections.Generic;
using System.Text;

namespace RiseFoodServiceWork.Models
{
    public class Supplie
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}

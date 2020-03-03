using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Ed1_ABB.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string NameDrug { get; set; }
        public int totalOrder { get; set; }
    }
}
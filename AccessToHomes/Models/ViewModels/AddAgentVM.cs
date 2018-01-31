using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessToHomes.Models.ViewModels
{
    public class AddAgentVM
    {
        public string Name { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string Address_3 { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
    }
}
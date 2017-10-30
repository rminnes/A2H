using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH.Models
{
    public class LettingAgent:AuditableEntity<long>
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

        public virtual ICollection<Listing> Listings { get; set; }

    }
}

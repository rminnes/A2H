using ATH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH.Models
{
    public class Listing :AuditableEntity<long>
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int Price { get; set; }
        public string Postcode { get; set; }
        public string LatLong { get; set; }

        public ICollection<ListingImage> Images { get; set; }

        public LettingAgent Agent { get; set;}

    }


}

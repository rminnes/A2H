using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH.Models
{
    public class ListingImage : Entity<long>
    {
        public string FileLocation { get; set; }
        public Listing Listing{get;set;}
    }
}

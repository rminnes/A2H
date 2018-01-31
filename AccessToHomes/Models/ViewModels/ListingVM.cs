using ATH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccessToHomes.Models.ViewModels
{
    public abstract class BaseListingVM
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }
        public string LongLat { get; set; }
        public int Bedrooms { get; set; }
        public bool Furnished { get; set; }
    }

    public class ListingVM : BaseListingVM
    {

        [Display(Name = "Images")]
        public HttpPostedFileBase[] Files { get; set; }
    }

    public class DisplayListingVM : BaseListingVM
    {
        public long Id { get; set; }

        public string FirstImage { get; set; }
        public List<string> Images { get; set; }

        public LettingAgent Agent { get; set; }

    }

}
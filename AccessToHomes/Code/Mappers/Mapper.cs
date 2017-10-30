using AccessToHomes.Models.ViewModels;
using ATH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessToHomes.Code.Mappers
{
    //public static class Mapper
    //{

    //    private static DisplayListingVM BaseToListingVM(Listing list)
    //    {
    //        var vm = new DisplayListingVM();

    //        vm.Title = list.Title;
    //        vm.ShortDescription = list.ShortDescription;
    //        vm.LongDescription = list.LongDescription;
    //        vm.Postcode = list.Postcode;
    //        vm.Price = list.Price;
    //        vm.LongLat = list.LatLong;
    //        vm.Images = new List<string>();
    //        foreach (var img in list.Images)
    //        {
    //            vm.Images.Add(img.FileLocation);
    //        }
    //        return vm;
    //    }

    //    public static DisplayListingVM ToListingVM(this Listing listing)
    //    {
    //            return BaseToListingVM(listing);
    //    }


    //    public static List<DisplayListingVM> ToListingsVM(this List<Listing> listings)
    //    {
    //        var listingVMs = new List<DisplayListingVM>();
    //        foreach (var list in listings)
    //        {
    //            listingVMs.Add( BaseToListingVM(list));
    //        }
    //        return listingVMs;
    //    }

    //}
}
using ATH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ATH.Services
{
    public interface IListingService:IEntityService<Listing>
    {
        Listing GetById(long Id);


        List<Listing> GetListings();

        List<Listing> GetListings(int count, int take);

        List<Listing> GetListings(int count, int take, int distance, double lat, double lng);


        void AddImages(Listing list, HttpPostedFileBase[] imgs);
    }
}

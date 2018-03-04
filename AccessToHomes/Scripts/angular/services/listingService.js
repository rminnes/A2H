listingsApp.service('listingService', function ($http) {
    this.allListings = function () {
        var $apiResponse = $http.get('/api/listingapi/getlistings');
        return $apiResponse;
    };

    this.getListing = function (id) {
        var $apiResponse = $http.get('/api/listingapi/GetListing?id=' + id);
        return $apiResponse;
    };

    this.addListing = function (title, address, shortDesc, longDesc,price, postcode, bedrooms, furnished) {
        //alert('listing added');

        var data = {
            Title: title,
            Address: address,
            ShortDescription: shortDesc,
            LongDescription: longDesc,
            Price: price,
            Postcode: postcode,
            Bedrooms: bedrooms,
            Furnished: furnished
        };
     
        var $apiResponse = $http.post('/api/listingapi/addListing', JSON.stringify(data));
        return $apiResponse
    };

});
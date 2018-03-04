listingsApp.controller("resultsCtrl",
    function ($scope, $http, listingService) {
        $scope.pageTitle = "test";

        $scope.distances = [1, 3, 5, 10, 25];

        listingService.allListings().then(function (result)
        {

            $scope.listings = result.data;
        });

         listingService.getListing(3).then(function (result) {
             $scope.premiumListing = result.data;
        });

    });

listingsApp.controller("addListingCtrl",
    function ($scope, $http, listingService) {
        $scope.title = "";
        $scope.address = "";
        $scope.shortDesc = "";
        $scope.longDesc = "";
        $scope.price = 0;
        $scope.postcode = "";
        $scope.bedrooms = "";
        $scope.furnished = true;

        $scope.submitForm = function () {
            alert('form submitted');
            listingService.addListing($scope.title, $scope.address, $scope.shortDesc, $scope.longDesc, $scope.price, $scope.postcode, $scope.bedrooms, $scope.furnished).then(function (result) {
                $scope.success = result.data;
            }, function (message) { alert(message); });
        };

        

    });
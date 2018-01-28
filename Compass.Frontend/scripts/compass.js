var Compass = /** @class */ (function () {
    function Compass(hours, updateAnalyticsUrl) {
        if (hours === void 0) { hours = Number.MAX_VALUE; }
        if (updateAnalyticsUrl === void 0) { updateAnalyticsUrl = "/analytics/setlocation?latitude={latitude}&longitude={longitude}"; }
        Compass.hoursToRefresh = hours;
        Compass.enpointUrl = updateAnalyticsUrl;
        this.initialize();
    }
    //Initialization
    Compass.prototype.initialize = function () {
        var _this = this;
        jQuery(document).ready(function () {
            var dateTime = jQuery.cookie(Compass.cookieDateOfCreation);
            if (dateTime) {
                //Previously, we get location from browser, checking how old is this information
                var date = new Date(dateTime);
                var currentDate = new Date();
                var timeDifference = Math.abs(currentDate.getTime() - date.getTime());
                var hoursDifference = Math.ceil(timeDifference / (1000 * 3600));
                if (hoursDifference > Compass.hoursToRefresh) {
                    //Getting location again if that was more than hoursToRefresh.
                    var allowedToGetLocation = jQuery.cookie(Compass.cookieSuccessGetLocation);
                    if (allowedToGetLocation) {
                        _this.tryGetLocation();
                    }
                }
            }
            else {
                //Getting location first time
                _this.tryGetLocation();
            }
        });
    };
    //Calling getting location from browsers
    Compass.prototype.tryGetLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(this.successGetCurrentPosition, this.failedGetCurrentPosition);
        }
        else {
            console.debug("Getting geolocation is not supported");
        }
    };
    //successCallback handler of navigator.geolocation.getCurrentPosition
    Compass.prototype.successGetCurrentPosition = function (position) {
        console.debug("Getting geolocation was allowed by user");
        console.debug("Latitude: " + position.coords.latitude);
        console.debug("Longitude: " + position.coords.longitude);
        jQuery.cookie(Compass.cookieSuccessGetLocation, true);
        jQuery.cookie(Compass.cookieDateOfCreation, new Date());
        jQuery.cookie(Compass.cookieLatitude, position.coords.latitude);
        jQuery.cookie(Compass.cookieLongitude, position.coords.longitude);
        Compass.sendLocationToServer(position);
    };
    //errorCallback handler of navigator.geolocation.getCurrentPosition
    Compass.prototype.failedGetCurrentPosition = function (error) {
        console.debug("Getting geolocation was denied by user");
        jQuery.cookie(Compass.cookieSuccessGetLocation, false);
        jQuery.cookie(Compass.cookieDateOfCreation, new Date());
    };
    //Sending coordinates to server
    //Was done static due to successCallback and errorCallback of navigator.geolocation.getCurrentPosition lost context
    //and it is not clear how to transfer context inside that functions
    Compass.sendLocationToServer = function (position) {
        var url = Compass.enpointUrl.replace("{latitude}", position.coords.latitude.toString()).replace("{longitude}", position.coords.longitude.toString()).toString();
        console.debug("Sending request to server by address: " + url);
        var settings = {
            url: url,
            type: "POST",
            async: true,
            error: function (xhr, status, error) {
                console.debug("Sending coordinates to server was failed");
                console.debug(error);
            },
            success: function (data) {
                console.debug("Coordinates were successfully sent to server");
                console.debug(data);
            }
        };
        jQuery.ajax(settings);
    };
    Compass.cookieDateOfCreation = "compass.DateTimeOfCreation";
    Compass.cookieSuccessGetLocation = "compass.SuccessGetLocation";
    Compass.cookieLatitude = "compass.Latitude";
    Compass.cookieLongitude = "compass.Longitude";
    return Compass;
}());
//# sourceMappingURL=compass.js.map
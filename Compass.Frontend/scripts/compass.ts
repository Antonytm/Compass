class Compass {
    public static readonly cookieDateOfCreation = "compass.DateTimeOfCreation";
    public static readonly cookieSuccessGetLocation = "compass.SuccessGetLocation";
    public static readonly cookieLatitude = "compass.Latitude";
    public static readonly cookieLongitude = "compass.Longitude";

    //amount of hours to refresh location
    static hoursToRefresh: number;
    //endpoint on server, where to send coordinates
    static enpointUrl: string;

    constructor(hours: number = Number.MAX_VALUE, updateAnalyticsUrl: string = "/analytics/setlocation?latitude={latitude}&longitude={longitude}") {
        Compass.hoursToRefresh = hours;
        Compass.enpointUrl = updateAnalyticsUrl;
        this.initialize();
    }

    //Initialization
    private initialize():void {
        jQuery(document).ready(() => {
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
                    if(allowedToGetLocation){
                        this.tryGetLocation();    
                    }
                }
            } else {
                //Getting location first time
                this.tryGetLocation();
            }
        });
    }

    //Calling getting location from browsers
    private tryGetLocation():void {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(this.successGetCurrentPosition, this.failedGetCurrentPosition);
        } else {
            console.debug("Getting geolocation is not supported");
        }
    }

    //successCallback handler of navigator.geolocation.getCurrentPosition
    private successGetCurrentPosition(position: Position): void {
        console.debug("Getting geolocation was allowed by user");
        console.debug("Latitude: " + position.coords.latitude);
        console.debug("Longitude: " + position.coords.longitude);
        jQuery.cookie(Compass.cookieSuccessGetLocation, true);
        jQuery.cookie(Compass.cookieDateOfCreation, new Date());
        jQuery.cookie(Compass.cookieLatitude, position.coords.latitude);
        jQuery.cookie(Compass.cookieLongitude, position.coords.longitude);
        Compass.sendLocationToServer(position);
    }

    //errorCallback handler of navigator.geolocation.getCurrentPosition
    private failedGetCurrentPosition(error: Object): void {
        console.debug("Getting geolocation was denied by user");
        jQuery.cookie(Compass.cookieSuccessGetLocation, false);
        jQuery.cookie(Compass.cookieDateOfCreation, new Date());
    }

    //Sending coordinates to server
    //Was done static due to successCallback and errorCallback of navigator.geolocation.getCurrentPosition lost context
    //and it is not clear how to transfer context inside that functions
    public static sendLocationToServer(position: Position) {
        var url = Compass.enpointUrl.replace("{latitude}", position.coords.latitude.toString()).replace("{longitude}", position.coords.longitude.toString()).toString();
        console.debug("Sending request to server by address: " + url);
        var settings: JQueryAjaxSettings = {
            url: url,
            type: "POST",
            async: true,
            error(xhr, status, error) {
                console.debug("Sending coordinates to server was failed");
                console.debug(error);
            },
            success(data) {
                console.debug("Coordinates were successfully sent to server");
                console.debug(data);
            }
        };
        jQuery.ajax(settings);
    }
}
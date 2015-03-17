define("App/Util/util", ['jquery', 'App/Util/logger'], function ($, logger) {

    if(!logger) {
        return undefined;
    }

    var self = this;
    self.objectState = {
        Unchanged: 0,
        Added: 1,
        Updated: 2,
        Deleted: 3
    };

    self.dataApi = {};
    self.dataApi.callService = function (options) {
        if(options && options.url) {
            var url = options.url;

            var httpMethod = options.method || 'GET';
            var parameters = options.params;
            var dataType = options.type || 'jsonp';
            var callback = options.callback;
            

            $.ajax({
                url: url,
                method: httpMethod,
                dataType:dataType,
                data: parameters,
            })
                .done(function (data, textStatus, jqxhr) {
                    if(options.callback) {
                        options.callback(data, textStatus, jqxhr);
                    }
                    //
                })
            .fail(function(jqxhr, textStatus, errorThrown) {
                logger.logMessage('Some error happened');
            })
            .always(function( data, textStatus, jqXHR) {
                logger.logMessage('Always executed');
            });
            
        }
        else {
            logger.logMessage('Please check the options object. The object is either undefined or the url is not set in it.');
        }

    };

   

    return {
        ObjectState: self.objectState,
        DataApi:self.dataApi
    };
});
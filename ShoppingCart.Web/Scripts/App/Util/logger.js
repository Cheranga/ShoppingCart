define('App/Util/logger', [], function() {
    
    var self = this;

    self.logMessage = function (message) {
        if (message) {
            console.log(message);
        }
    };

    return {
        logMessage: self.logMessage
    };
})
var shocart = shocart || {};

shocart.SalesOrder = function (options) {
    //
    // The options will be parsed the KO to create the relevant properties
    //
    var self = this;

    if(options) {
        self = ko.mapping.fromJS(options);

        return self;
    }
    return undefined;
};
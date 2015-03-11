//var shocart = shocart || {};

//shocart.SalesOrder = function (options) {
//    //
//    // The options will be parsed the KO to create the relevant properties
//    //
//    var self = this;

//    if(options) {
//        self = ko.mapping.fromJS(options);

//        return self;
//    }
//    return undefined;
//};

define('App/Models/salesorder', ['jquery', 'knockout', 'komapping','App/Util/util'], function ($,ko,kom, util) {
    
    var self = this;

    self.SalesOrder = function (options) {

        options = options || {
            id: 0,
            customerName: '',
            poNumber: ''
        };
        
        options.objectState = options.objectState || util.ObjectState.Added;
        //
        // Use "kom" to use the "fromJS" call, because that method is exposed in the "kom" object, NOT in the "ko"
        //
        var salesOrder = kom.fromJS(options);
        //
        // If needed add additional observables/computed observables/functions/behaviours to the "salesOrder" object
        //

        return salesOrder;
    };

    return {
        SalesOrder: self.SalesOrder
    };
});
//var shocart = shocart || {};

//shocart.SalesOrderListViewModel = function () {
//    var self = this;

//    //
//    // Observables
//    //
//    self.orders = ko.observableArray([]);

//    //
//    // Computed
//    //
//    self.orderCount = ko.computed(function () {
//        var orders = ko.unwrap(self.orders);
//        return orders ? orders.length : 0;
//    });

//    self.haveOrders = ko.computed(function() {
//        var orderCount = ko.unwrap(self.orderCount);
//        return orderCount > 0;
//    });
//    //
//    // Functions
//    //
//    self.addOrder = function (salesOrder) {
//        if(salesOrder) {
//            self.orders.push(salesOrder);
//        }
//    };
//    //
//    // API
//    //
//    return {
//        orders: self.orders,
//        orderCount: self.orderCount,
//        haveOrders: self.haveOrders,
//        addOrder: self.addOrder
//    };
//};


define('App/ViewModels/salesorderlistviewmodel', ['jquery', 'knockout', 'komapping', 'App/Models/salesorder', 'App/Util/util'], function ($, ko, kom, salesOrder, util) {

    var self = this;

    self.SalesOrderListViewModel = function () {
        var vm = this;

        //
        // Observables
        //
        vm.salesOrders = ko.observableArray([]);

        //
        // Computed observables
        //
        vm.currentSalesOrderCount = ko.computed(function () {
            var length = ko.unwrap(vm.salesOrders).length;
            return length;
        });

        //
        // Functions
        //
        vm.salesOrdersReceived = function (data, textStatus, jqxhr) {
            if (data) {
                //
                // To get the observable array, need to call the method
                //
                var transformedSalesOrders = kom.fromJS(data)();
                //
                // After getting the observable array, set the orders
                //
                vm.salesOrders(transformedSalesOrders);
            }
        };
        vm.getSalesOrders = function () {
            var options = {
                url: "http://localhost/ShoCartService/api/values",
                callback:vm.salesOrdersReceived
            };

            util.DataApi.callService(options);
        };

        //
        // Behaviours
        //

        //
        // API
        //
        return {
            orders: vm.salesOrders,
            getSalesOrders:vm.getSalesOrders
        };
    };

    return {
        ViewModel: self.SalesOrderListViewModel
    };

});
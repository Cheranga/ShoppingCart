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


define('App/ViewModels/salesorderlistviewmodel', ['jquery', 'knockout', 'komapping', 'App/Models/salesorder'], function ($,ko, kom, salesOrder) {
    
    var self = this;

    self.SalesOrderListViewModel = function () {
        var vm = this;

        vm.salesOrders = ko.observableArray([]);

        vm.currentSalesOrderCount = ko.computed(function() {
            var length = ko.unwrap(self.salesOrders).length;
            return length;
        });

        vm.getSalesOrders = function (page, pageSize) {
            //
            // First check whether we have the requested sales orders in the list
            //
            var curCount = ko.unwrap(vm.currentSalesOrderCount);
            var reqData = page * pageSize;

        };

    };

});
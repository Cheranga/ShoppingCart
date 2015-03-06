var shocart = shocart || {};

shocart.SalesOrderListViewModel = function () {
    var self = this;

    //
    // Observables
    //
    self.orders = ko.observableArray([]);

    //
    // Computed
    //
    self.orderCount = ko.computed(function () {
        var orders = ko.unwrap(self.orders);
        return orders ? orders.length : 0;
    });

    self.haveOrders = ko.computed(function() {
        var orderCount = ko.unwrap(self.orderCount);
        return orderCount > 0;
    });
    //
    // Functions
    //
    self.addOrder = function (salesOrder) {
        if(salesOrder) {
            self.orders.push(salesOrder);
        }
    };
    //
    // API
    //
    return {
        orders: self.orders,
        orderCount: self.orderCount,
        haveOrders: self.haveOrders,
        addOrder: self.addOrder
    };
};
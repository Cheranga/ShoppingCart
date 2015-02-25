var shocart = shocart || {};

shocart.SalesOrderListViewModel = function () {
    var self = this;

    //
    // Originals
    //
    self.orders = ko.observableArray([]);

    //
    // Computed
    //
    self.orderCount = ko.computed(function () {
        var orders = self.orders();
        return orders ? orders.length : 0;
    });

    self.haveOrders = ko.computed(function() {
        var orderCount = self.orderCount();
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
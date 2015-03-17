require(['jquery', 'knockout', 'App/ViewModels/salesorderlistviewmodel'], function ($, ko, vm) {

    $(function () {

        //
        // Create the view model and bind it to the view
        //
        var viewModel = new vm.ViewModel();
        ko.applyBindings(viewModel);
        //
        // Now call the web service to get the sales orders
        //
        viewModel.getSalesOrders();
    });

});
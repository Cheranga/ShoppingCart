using ShoppingCart.Business.Models;

namespace ShoppingCart.DTO.Extensions.ModelExtensions
{
    public static partial class ModelExtensions
    {
        public static SalesOrderDTO ToDTO(this SalesOrder salesOrder)
        {
            var viewModel = new SalesOrderDTO
            {
                Id = salesOrder.Id,
                CustomerName = salesOrder.CustomerName,
                PONumber = salesOrder.PONumber
            };

            return viewModel;
        }

        public static SalesOrder ToModel(this SalesOrderDTO salesOrderDto)
        {
            var model = new SalesOrder
            {
                Id = salesOrderDto.Id,
                CustomerName = salesOrderDto.CustomerName,
                PONumber = salesOrderDto.PONumber
            };

            return model;
        }
    }
}
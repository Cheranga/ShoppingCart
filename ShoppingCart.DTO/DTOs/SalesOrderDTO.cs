using ShoppingCart.Infrastructure;

namespace ShoppingCart.DTO.DTOs
{
    public class SalesOrderDTO : IDto, IObjectWithState
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PONumber { get; set; }

        public string StatusMessage { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}

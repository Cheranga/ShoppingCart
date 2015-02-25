namespace ShoppingCart.DTO.DTOs
{
    public class SalesOrderDTO : IDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PONumber { get; set; }

        public string StatusMessage { get; set; }
    }
}

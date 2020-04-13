using API.Dtos.Accout;

namespace API.Dtos.Customer
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public decimal Dortadim { get; set; }
        public AddressDto ShipToAddress { get; set; }
    }
}
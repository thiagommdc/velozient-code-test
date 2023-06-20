using System.ComponentModel.DataAnnotations;

namespace drone_delivery_service_api.Domain
{
    public class Delivery
    {
        [Key]
        public int ID { get; set; }
        public string Location { get; set; }
        public int Weight { get; set; }
    }   
}

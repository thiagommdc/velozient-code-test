using System.ComponentModel.DataAnnotations;

namespace drone_delivery_service_api.Domain
{
    public class Drone
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxWeight { get; set; }
    }
}

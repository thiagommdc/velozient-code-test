namespace drone_delivery_service_api.Domain
{
    public class DroneLocations : Drone
    {
        public List<List<string>> Trips { get; set; }
    }
}

using drone_delivery_service_api.Domain;

namespace drone_delivery_service_api.Business.Interface
{
    public interface IDroneBusiness
    {
        List<Drone> Drones();
        void IncludeDrones(List<Drone> drones);
        void UpdateDrones(List<Drone> drones);
        void DeleteDrone(Drone drones);
    }
}

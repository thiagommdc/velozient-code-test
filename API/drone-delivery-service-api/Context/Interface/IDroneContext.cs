using drone_delivery_service_api.Business;
using drone_delivery_service_api.Domain;

namespace drone_delivery_service_api.Context.Interface
{
    public interface IDroneContext
    {
        List<Drone> Drones();
        void IncludeDrones(List<Drone> drones);
        void UpdateDrones(List<Drone> drones);
        void DeleteDrone(Drone drones);
    }
}
